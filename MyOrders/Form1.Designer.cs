namespace MyOrders
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доставкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытыеЗаказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрагентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветаПлатежейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.валютыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.платежиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.балансToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетПоПлатежамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблоныПлатежейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетПоДоставкамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.калькуляцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеПредложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникОборудованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникПроизводителейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.калькуляцияToolStripMenuItem,
            this.предложенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.доставкиToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.закрытыеЗаказыToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.платежиToolStripMenuItem,
            this.балансToolStripMenuItem,
            this.отчетПоПлатежамToolStripMenuItem,
            this.шаблоныПлатежейToolStripMenuItem,
            this.отчетПоДоставкамToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // доставкиToolStripMenuItem
            // 
            this.доставкиToolStripMenuItem.Name = "доставкиToolStripMenuItem";
            this.доставкиToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.доставкиToolStripMenuItem.Text = "Доставки";
            this.доставкиToolStripMenuItem.Click += new System.EventHandler(this.доставкиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // закрытыеЗаказыToolStripMenuItem
            // 
            this.закрытыеЗаказыToolStripMenuItem.Name = "закрытыеЗаказыToolStripMenuItem";
            this.закрытыеЗаказыToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.закрытыеЗаказыToolStripMenuItem.Text = "Закрытые заказы";
            this.закрытыеЗаказыToolStripMenuItem.Click += new System.EventHandler(this.закрытыеЗаказыToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.контрагентыToolStripMenuItem,
            this.цветаПлатежейToolStripMenuItem,
            this.валютыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            this.справочникиToolStripMenuItem.Click += new System.EventHandler(this.справочникиToolStripMenuItem_Click);
            // 
            // контрагентыToolStripMenuItem
            // 
            this.контрагентыToolStripMenuItem.Name = "контрагентыToolStripMenuItem";
            this.контрагентыToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.контрагентыToolStripMenuItem.Text = "Контрагенты";
            this.контрагентыToolStripMenuItem.Click += new System.EventHandler(this.контрагентыToolStripMenuItem_Click);
            // 
            // цветаПлатежейToolStripMenuItem
            // 
            this.цветаПлатежейToolStripMenuItem.Name = "цветаПлатежейToolStripMenuItem";
            this.цветаПлатежейToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.цветаПлатежейToolStripMenuItem.Text = "Цвета платежей";
            this.цветаПлатежейToolStripMenuItem.Click += new System.EventHandler(this.цветаПлатежейToolStripMenuItem_Click);
            // 
            // валютыToolStripMenuItem
            // 
            this.валютыToolStripMenuItem.Name = "валютыToolStripMenuItem";
            this.валютыToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.валютыToolStripMenuItem.Text = "Валюты";
            this.валютыToolStripMenuItem.Click += new System.EventHandler(this.валютыToolStripMenuItem_Click);
            // 
            // платежиToolStripMenuItem
            // 
            this.платежиToolStripMenuItem.Name = "платежиToolStripMenuItem";
            this.платежиToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.платежиToolStripMenuItem.Text = "Платежи";
            this.платежиToolStripMenuItem.Click += new System.EventHandler(this.платежиToolStripMenuItem_Click);
            // 
            // балансToolStripMenuItem
            // 
            this.балансToolStripMenuItem.Name = "балансToolStripMenuItem";
            this.балансToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.балансToolStripMenuItem.Text = "Баланс";
            this.балансToolStripMenuItem.Click += new System.EventHandler(this.балансToolStripMenuItem_Click);
            // 
            // отчетПоПлатежамToolStripMenuItem
            // 
            this.отчетПоПлатежамToolStripMenuItem.Name = "отчетПоПлатежамToolStripMenuItem";
            this.отчетПоПлатежамToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.отчетПоПлатежамToolStripMenuItem.Text = "Отчет по платежам";
            this.отчетПоПлатежамToolStripMenuItem.Click += new System.EventHandler(this.отчетПоПлатежамToolStripMenuItem_Click);
            // 
            // шаблоныПлатежейToolStripMenuItem
            // 
            this.шаблоныПлатежейToolStripMenuItem.Name = "шаблоныПлатежейToolStripMenuItem";
            this.шаблоныПлатежейToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.шаблоныПлатежейToolStripMenuItem.Text = "Шаблоны платежей";
            this.шаблоныПлатежейToolStripMenuItem.Click += new System.EventHandler(this.шаблоныПлатежейToolStripMenuItem_Click);
            // 
            // отчетПоДоставкамToolStripMenuItem
            // 
            this.отчетПоДоставкамToolStripMenuItem.Name = "отчетПоДоставкамToolStripMenuItem";
            this.отчетПоДоставкамToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.отчетПоДоставкамToolStripMenuItem.Text = "Отчет по доставкам";
            this.отчетПоДоставкамToolStripMenuItem.Click += new System.EventHandler(this.отчетПоДоставкамToolStripMenuItem_Click);
            // 
            // калькуляцияToolStripMenuItem
            // 
            this.калькуляцияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.настройкиToolStripMenuItem1,
            this.справочникТоваровToolStripMenuItem});
            this.калькуляцияToolStripMenuItem.Name = "калькуляцияToolStripMenuItem";
            this.калькуляцияToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.калькуляцияToolStripMenuItem.Text = "Калькуляция";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.создатьToolStripMenuItem.Text = "Старт";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки";
            this.настройкиToolStripMenuItem1.Click += new System.EventHandler(this.настройкиToolStripMenuItem1_Click);
            // 
            // справочникТоваровToolStripMenuItem
            // 
            this.справочникТоваровToolStripMenuItem.Name = "справочникТоваровToolStripMenuItem";
            this.справочникТоваровToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.справочникТоваровToolStripMenuItem.Text = "Справочник товаров";
            this.справочникТоваровToolStripMenuItem.Click += new System.EventHandler(this.справочникТоваровToolStripMenuItem_Click);
            // 
            // предложенияToolStripMenuItem
            // 
            this.предложенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеПредложенияToolStripMenuItem,
            this.справочникОборудованияToolStripMenuItem,
            this.справочникПроизводителейToolStripMenuItem});
            this.предложенияToolStripMenuItem.Name = "предложенияToolStripMenuItem";
            this.предложенияToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.предложенияToolStripMenuItem.Text = "Предложения";
            // 
            // всеПредложенияToolStripMenuItem
            // 
            this.всеПредложенияToolStripMenuItem.Name = "всеПредложенияToolStripMenuItem";
            this.всеПредложенияToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.всеПредложенияToolStripMenuItem.Text = "Все предложения";
            this.всеПредложенияToolStripMenuItem.Click += new System.EventHandler(this.всеПредложенияToolStripMenuItem_Click);
            // 
            // справочникОборудованияToolStripMenuItem
            // 
            this.справочникОборудованияToolStripMenuItem.Name = "справочникОборудованияToolStripMenuItem";
            this.справочникОборудованияToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.справочникОборудованияToolStripMenuItem.Text = "Справочник оборудования";
            this.справочникОборудованияToolStripMenuItem.Click += new System.EventHandler(this.справочникОборудованияToolStripMenuItem_Click);
            // 
            // справочникПроизводителейToolStripMenuItem
            // 
            this.справочникПроизводителейToolStripMenuItem.Name = "справочникПроизводителейToolStripMenuItem";
            this.справочникПроизводителейToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.справочникПроизводителейToolStripMenuItem.Text = "Справочник производителей";
            this.справочникПроизводителейToolStripMenuItem.Click += new System.EventHandler(this.справочникПроизводителейToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 510);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Главная";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доставкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытыеЗаказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрагентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem платежиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem балансToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетПоПлатежамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветаПлатежейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблоныПлатежейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem валютыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетПоДоставкамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem калькуляцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справочникТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предложенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеПредложенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникОборудованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникПроизводителейToolStripMenuItem;
    }
}

