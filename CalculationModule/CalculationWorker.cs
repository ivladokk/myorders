using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using Newtonsoft.Json;

namespace CalculationModule
{
    public class ImportedProduct
    {
        public Product Product;
        public int Count;
        public long TNVEDCode;
        public decimal TNVEDValue;
    }

    public class CalculatedValue
    {

        public CalculationItem Item { get; set; }
        public decimal Value { get; set; }
    }

    public class CalculatedProduct
    {
        public ImportedProduct Product { get; set; }
        public List<CalculatedValue> CalculatedValues { get; set; }
    }

    public class ItemSum
    {
        public CalculationItem Item { get; set; }
        public decimal Value { get; set; }
    }
    /*
    public class CalculationOrder
    {
        public int Order { get; set; }
        public int ItemType { get; set; }//1-item, 2-dynamic,3-sum
        public int ItemID { get; set; }
    }*/

    public class CalculatedDynamic
    {
        public DynamicConstant Dynamic { get; set; }
        public decimal Value { get; set; }
    }
    public class CalculationWorker
    {
        public List<ImportedProduct> Products = new List<ImportedProduct>();
        public CalculationInstance calculationInstance;
        private IEnumerable<CalculationItem> _calculationItems;
        private List<CalculationConstant> _usedConstatns;

        public List<CalculatedProduct> calculatedProducts = new List<CalculatedProduct>();

        public List<ImportedProduct> FailedImportedProducts = new List<ImportedProduct>();

        public List<ItemSum> ItemSumList = new List<ItemSum>();

        public List<DynamicConstant> dynamicConst = new List<DynamicConstant>();

        public List<CalculationOrder> order = new List<CalculationOrder>();
        public List<CalculatedDynamic> CalculatedDynamics = new List<CalculatedDynamic>();
        private int _mode;

        public CalculationWorker()
        {
            _mode = 1;
        }
        public CalculationWorker(CalculationInstance instance)
        {
            _mode = 2;
            calculationInstance = instance;
            LoadEnviroment();
            ImportFromJSON();
        }
        public void CreateInstance(int typeID, string name, int agentID, int agentID2)
        {
            if (_mode != 1)
            {
                return;
            }
            var instance = new CalculationInstance  
            {
                CalculationTypeID = typeID,
                CreateDate = DateTime.Today,
                Name = name,
                ContrAgentID = agentID,
                ContrAgentID2 = agentID2,
                Status = 1
            };
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.CalculationInsctInstances.Add(instance);
                db.SaveChanges();
                calculationInstance = instance;
            }

            LoadEnviroment();
        }

        public void LoadEnviroment()
        {
            if (calculationInstance == null)
            {
                MessageBox.Show("Ошибка при загрузке элементов");
                return;
            }
            using (UserContext db = new UserContext(Settings.constr))
            {
                _calculationItems = db.CalculationItems
                    .Where(x => x.CalculationTypeID == calculationInstance.CalculationTypeID).ToList();
                _usedConstatns = db.CalculationConstants
                    .Where(x => x.CalculationTypeID == calculationInstance.CalculationTypeID && x.ConstantType == 1).ToList();
                dynamicConst = db.DynamicConstants
                    .Where(x => x.CalculationTypeID == calculationInstance.CalculationTypeID).ToList();
                order = db.CalculationOrders.Where(x => x.CalculationTypeID == calculationInstance.CalculationTypeID).ToList();
            }
        }

        public void ProcessNew()
        {

            foreach (var pr in Products)
            {
                CalculatedProduct calcProduct = new CalculatedProduct
                {
                    Product = pr,
                    CalculatedValues = new List<CalculatedValue>()
                };
                calculatedProducts.Add(calcProduct);
            }


            foreach (var ord in order.OrderBy(x=>x.Order))
            {
                switch (ord.ItemType)
                {
                    case 1:
                    {
                        var item = _calculationItems.FirstOrDefault(x => x.ID == ord.ItemID);
                        CalculateItem(item);
                        break;
                    }
                    case 2:
                    {
                        var dynamic = dynamicConst.FirstOrDefault(x => x.ID == ord.ItemID);
                        CalculateDynamic(dynamic);
                        break;
                    }
                    case 3:
                    {
                        var item = _calculationItems.FirstOrDefault(x => x.ID == ord.ItemID);
                        GetSum(item);
                        break;
                    }
                }
            }
        }


        private void CalculateItem(CalculationItem item)
        {
            foreach (var pr in calculatedProducts)
            {
                var calcValue = new CalculatedValue
                {
                    Item = item,
                    Value = CalculateValue(ParseExpression(pr.Product, item, pr.CalculatedValues), item.NeedRound == 1)
                };
                pr.CalculatedValues.Add(calcValue);
            }
        }

        private void CalculateDynamic(DynamicConstant dynamic)
        {
            Dictionary<string,string> replace = new Dictionary<string, string>();
            string constantPattern = @"constant\[\d+\]";

            foreach (Match match in Regex.Matches(dynamic.Expression, constantPattern))
            {
                string pattern = @"\d+";
                var constantId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());

                var constantValue = _usedConstatns.FirstOrDefault(x => x.ID == constantId);
                if (constantValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, constantValue.Value.ToString());
                }
            }

            string sumPattern = @"sum\[\d+\]";
            foreach (Match match in Regex.Matches(dynamic.Expression, sumPattern))
            {
                string pattern = @"\d+";

                var itemId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());
                var sumValue = ItemSumList.FirstOrDefault(x => x.Item.ID == itemId);
                if (sumValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, sumValue.Value.ToString());
                }
            }

            var ret = dynamic.Expression;
            foreach (var i in replace)
            {
                ret = ret.Replace(i.Key, i.Value);
            }

            var value = CalculateValue(ret);
            CalculatedDynamics.Add(new CalculatedDynamic
            {
                Dynamic = dynamic, Value = value
            });

        }
        private void GetSum(CalculationItem item)
        {
            decimal ret = 0;
            foreach (var i in calculatedProducts)
            {
                foreach (var val in i.CalculatedValues.Where(x => x.Item.ID == item.ID))
                {
                    ret += val.Value;
                }
            }

            ItemSumList.Add(new ItemSum { Item = item, Value = ret });
        }
        public void ImportProducts(DataTable dt)
        {

            /*dt.Columns[0].ColumnName = "Num";
            dt.Columns[1].ColumnName = "VendorCode";
            dt.Columns[2].ColumnName = "ProductName";
            dt.Columns[3].ColumnName = "Count";
            dt.Columns[5].ColumnName = "Price";*/
            try
            {
                Products.Clear();
                List<ImportedProduct> products = new List<ImportedProduct>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var pr = new ImportedProduct
                    {
                        Product = new Product
                        {
                            Name = dt.Rows[i]["ProductName"].ToString(),
                            Price = Convert.ToDecimal(dt.Rows[i]["Price"].ToString().Replace(".", ",")),
                            VendorCode = dt.Rows[i]["VendorCode"].ToString()
                        },
                        Count = Convert.ToInt32(dt.Rows[i]["Count"].ToString())
                    };
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        var code = db.ProductAttributes.FirstOrDefault(x =>
                            x.VendorCode == pr.Product.VendorCode.ToUpper());
                        if (code != null)
                        {
                            pr.TNVEDCode = code.TNVEDCode;
                            pr.TNVEDValue = code.TNVEDValue;
                        }
                        else
                        {
                            FailedImportedProducts.Add(pr);
                        }
                    }
                    products.Add(pr);
                }

                Products = products;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при импорте!");
            }
            
            
        }

        public void Process()
        {
            foreach (var product in Products)
            {
                CalculatedProduct calcProduct = new CalculatedProduct
                {
                    Product = product,
                    CalculatedValues = new List<CalculatedValue>()
                };

                foreach (var item in _calculationItems.OrderBy(x => x.OrderID))
                {
                    var calcValue = new CalculatedValue
                    {
                        Item = item,
                        Value = CalculateValue(ParseExpression(calcProduct.Product, item, calcProduct.CalculatedValues))
                    };
                    calcProduct.CalculatedValues.Add(calcValue);
                }

                calculatedProducts.Add(calcProduct);
               
            }
        }

        public void FillConstants(List<CalculationConstant> manualConstants)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                _usedConstatns = db.CalculationConstants.Where(x => x.CalculationTypeID == calculationInstance.ID)
                    .ToList();
            }

            foreach (var i in _usedConstatns.Where(x => x.ConstantType == 2))
            {

                _usedConstatns.Remove(i);
            }

            _usedConstatns.AddRange(manualConstants);
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable("Report");
            DataColumn col1 = new DataColumn
            {
                ColumnName = $"Product",
                Caption = $"Название товара"
            };
            DataColumn col2 = new DataColumn
            {
                ColumnName = "Count",
                Caption = "Кол-во"
            };
            DataColumn col3 = new DataColumn
            {
                ColumnName = "Price",
                Caption = "Цена за шт"
            };
            DataColumn col4 = new DataColumn
            {
                ColumnName = $"VendorCode",
                Caption = $"Артикул"
            };
            dt.Columns.Add(col1);
            dt.Columns.Add(col4);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
           
            foreach (var i in _calculationItems)
            {
                dt.Columns.Add(new DataColumn()
                {
                    ColumnName = i.ItemName,
                    Caption = i.ItemName
                });
            }

            for (int i = 0; i < calculatedProducts.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i]["Product"] = calculatedProducts[i].Product.Product.Name;
                dt.Rows[i]["VendorCode"] = calculatedProducts[i].Product.Product.VendorCode;
                dt.Rows[i]["Count"] = calculatedProducts[i].Product.Count;
                dt.Rows[i]["Price"] = calculatedProducts[i].Product.Product.Price;
                foreach (var item in calculatedProducts[i].CalculatedValues)
                {
                    dt.Rows[i][item.Item.ItemName] = item.Value;
                }
            }

            try
            {
                dt.Rows.Add();
                int lastRow = dt.Rows.Count - 1;
                dt.Rows[lastRow]["Product"] = "Сумма";
                foreach (var item in _calculationItems.Where(x => x.WithSum == 1))
                {
                    dt.Rows[lastRow][item.ItemName] = ItemSumList.FirstOrDefault(x => x.Item.ItemName == item.ItemName).Value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при расчете сумммы");
            }

            try
            {
                foreach (var i in CalculatedDynamics)
                {
                    dt.Rows.Add();
                    int lastRow = dt.Rows.Count - 1;
                    dt.Rows[lastRow][0] = $"{i.Dynamic.Name}:{i.Value}";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

            return dt;
        }

        public void SaveResults()
        {
            ExportToJSON();
        }

        public void SaveForSearch()
        {
            var products = new List<AppCore.Models.CalculatedProduct>();

            foreach (var i in calculatedProducts)
            {
                AppCore.Models.CalculatedProduct pr = new AppCore.Models.CalculatedProduct
                {
                    CalculationInstanceID = calculationInstance.ID,
                    ProductName = i.Product.Product.Name,
                    VendorCode = i.Product.Product.VendorCode,
                    Count = i.Product.Count,
                    Price = i.Product.Product.Price
                };
                products.Add(pr);
            }

            using (UserContext db = new UserContext(Settings.constr))
            {
                db.CalculatedProducts.AddRange(products);
                db.SaveChanges();
            }

        }

        private decimal CalculateValue(string parsedEpression, bool round = false)
        {
            try
            {
                var loDataTable = new DataTable();
                parsedEpression = parsedEpression.Replace(",", ".");
                var loDataColumn = new DataColumn("Eval", typeof(decimal), parsedEpression);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);
                var res = Convert.ToDecimal(loDataTable.Rows[0]["Eval"]);

                return round ? Round(Decimal.Round(res, 2)) : Decimal.Round(res, 2);
            }
            catch (Exception e)
            {
                MessageBox.Show($"ошибка при парсинге выражения {parsedEpression} : {e.Message}");
                return -9999999;
            }
            
        }

        private decimal Round(decimal price)
        {
            var DecPrice = price * 2;
            var roundedPrice = Math.Round(DecPrice, MidpointRounding.AwayFromZero);
            var finalPrice = roundedPrice / 2;

            return finalPrice;
        }

        private string ParseExpression(ImportedProduct product, CalculationItem item, List<CalculatedValue> caclulatedValues)
        {
            
            Dictionary<string, string> replace = new Dictionary<string, string>();
            

            string itemPattern = @"item\[\d+\]";
            foreach (Match match in Regex.Matches(item.Expression, itemPattern))
            {
                string pattern = @"\d+";
                
                var itemId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());

                var itemValue = caclulatedValues.FirstOrDefault(x => x.Item.ID == itemId);
                if (itemValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, itemValue.Value.ToString());
                }
            }

            string constantPattern = @"constant\[\d+\]";

            foreach (Match match in Regex.Matches(item.Expression, constantPattern))
            {
                string pattern = @"\d+";
                var constantId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());

                var constantValue = _usedConstatns.FirstOrDefault(x => x.ID == constantId);
                if (constantValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, constantValue.Value.ToString());
                }
            }

            string sumPattern = @"sum\[\d+\]";
            foreach (Match match in Regex.Matches(item.Expression, sumPattern))
            {
                string pattern = @"\d+";

                var itemId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());
                var sumValue = ItemSumList.FirstOrDefault(x => x.Item.ID == itemId);
                if (sumValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, sumValue.Value.ToString());
                }
            }

            string dynamicPattern = @"dynamic\[\d+\]";
            foreach (Match match in Regex.Matches(item.Expression, dynamicPattern))
            {
                string pattern = @"\d+";

                var dynamicId = Convert.ToInt32(Regex.Match(match.Value, pattern).ToString());
                var dynamicValue = CalculatedDynamics.FirstOrDefault(x => x.Dynamic.ID == dynamicId);
                if (dynamicValue != null)
                {
                    if (!replace.ContainsKey(match.Value))
                        replace.Add(match.Value, dynamicValue.Value.ToString());
                }
            }


            replace.Add("price", product.Product.Price.ToString());
            replace.Add("count", product.Count.ToString());
            replace.Add("TNVEDCode", product.TNVEDCode.ToString());
            replace.Add("TNVEDValue", product.TNVEDValue.ToString());
            var ret = item.Expression;
            foreach (var i in replace)
            {
                ret = ret.Replace(i.Key, i.Value);
            }
            return ret;
        }

        private void ExportToJSON()
        {
            var data = new CalculationJson
            {
                products = calculatedProducts,
                sum = ItemSumList,
                dymamics = CalculatedDynamics
            };
            var result = JsonConvert.SerializeObject(data);
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.CalculationResults.Add(new CalculationResult
                {
                    CalculationInstanseID = calculationInstance.ID,
                    CalculatedProducts = result
                });
                db.SaveChanges();
            }
        }

        private void ImportFromJSON()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var data = db.CalculationResults.FirstOrDefault(x => x.CalculationInstanseID == calculationInstance.ID);
                var result = JsonConvert.DeserializeObject<CalculationJson>(data.CalculatedProducts);
                calculatedProducts = result.products;
                ItemSumList = result.sum;
                CalculatedDynamics = result.dymamics;
            }
        }
    }

    public class CalculationJson
    {
        public List<CalculatedProduct> products { get; set; }
        public List<ItemSum> sum { get; set; }
        public List<CalculatedDynamic> dymamics { get; set; }
    }
}
