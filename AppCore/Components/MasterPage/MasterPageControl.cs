using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore.Components.MasterPage
{
    public partial class MasterPageControl : UserControl
    {
        private List<MasterPageItem> _pages;

        private MasterPageItem _currentItem;
        public MasterPageItem CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                ShowCurrentItem();
                if (value.isLast)
                {
                    nextBtn.Visible = false;
                    backBtn.Visible = false;
                    cancelBtn.Visible = false;
                    finishBtn.Visible = true;
                }
                else
                if (value.isFirst)
                {
                    nextBtn.Visible = true;
                    backBtn.Visible = false;
                    cancelBtn.Visible = true;
                    finishBtn.Visible = false;
                }
                else
                {
                    nextBtn.Visible = true;
                    backBtn.Visible = true;
                    cancelBtn.Visible = true;
                    finishBtn.Visible = false;
                }
            }
        }

        public MasterPageControl()
        {

        }
        private void ShowCurrentItem()
        {
            ContentLayout.Controls.Clear();
            ContentLayout.Controls.Add(CurrentItem.ItemContent);
        }

        public MasterPageControl(List<MasterPageItem> pages)
        {
            InitializeComponent();
            _pages = pages;
            CurrentItem = _pages.FirstOrDefault(x => x.isFirst);

        }

        public void NextPage()
        {
            if (CurrentItem.isNextAvaible)
                CurrentItem = _currentItem.NextItem;
        }

        public void PreviousPage()
        {
            CurrentItem = CurrentItem.PreviousItem;
        }

        public void Cancel()
        {

        }

        public void Finish()
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
