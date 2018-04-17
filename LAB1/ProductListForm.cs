using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB1
{
    public partial class ProductListForm : DevExpress.XtraEditors.XtraForm
    {
        public ProductListForm()
        {
            InitializeComponent();
        }
        public static int actionButton;
        const int FUNCTION_ADD = 1;
        const int FUNCTION_EDIT = 2;
        public static int index;
        public static List<string> listCodeProducts;
        public static Products product;
        static DataTable dataTableProducts;
        private void DumpDataTableToListView(DataTable datatable)
        {
            ProductslistView.Items.Clear();
            foreach (DataRow dataRow in datatable.Rows)
            {
                ListViewItem itemListView = new ListViewItem(dataRow["Code"].ToString());
                itemListView.SubItems.Add(dataRow["Name"].ToString());
                itemListView.SubItems.Add(dataRow["Price"].ToString());
                itemListView.SubItems.Add(dataRow["Date"].ToString());
                itemListView.SubItems.Add(dataRow["Category"].ToString());
                ProductslistView.Items.Add(itemListView);
            }
        }
        private void DisplayListView()
        {
            dataTableProducts = new DataTable();
            dataTableProducts = DataTableProducts.AddRows();
            DumpDataTableToListView(dataTableProducts);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayListView();
        }
        private void AddProductToListView(Products product)
        {
            ListViewItem itemListView = new ListViewItem(product.Code);
            itemListView.SubItems.Add(product.Name);
            itemListView.SubItems.Add(product.Price);
            itemListView.SubItems.Add(product.Date.ToString("dd/MM/yyyy"));
            itemListView.SubItems.Add(product.Category);
            ProductslistView.Items.Add(itemListView);
        }
        private void GetListCodeProducts()
        {
            listCodeProducts = new List<string>();
            for (int i = 0; i < ProductslistView.Items.Count; i++)
            {
                listCodeProducts.Add(ProductslistView.Items[i].SubItems[0].Text);
            }
        }
        private bool CheckExistForm(string nameForm)
        {
            bool check = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == nameForm)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string nameForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == nameForm)
                {
                    form.Activate();
                    break;
                }
            }
        }
        // button Add
        private void AddsimpleButton_Click(object sender, EventArgs e)
        {
            actionButton = FUNCTION_ADD;
            ProductDetail productDetailForm = new ProductDetail();
            if (CheckExistForm("ProductDetail") == false)
            {
                GetListCodeProducts();
                productDetailForm.addProducts = new ProductDetail.AddProducts(AddProductToListView);
                productDetailForm.Show();
            }
            else
            {
                ActiveChildForm("ProductDetail");
            }
        }
        private void GetInfomationProduct(int index)
        {
            product = new Products();
            product.Code = ProductslistView.Items[index].SubItems[0].Text;
            product.Name = ProductslistView.Items[index].SubItems[1].Text;
            product.Price = ProductslistView.Items[index].SubItems[2].Text;
            product.Date = Convert.ToDateTime(ProductslistView.Items[index].SubItems[3].Text);
            product.Category = ProductslistView.Items[index].SubItems[4].Text;
        }
        private void EditProductToListView(Products product)
        {
            ProductslistView.SelectedItems[0].SubItems[1].Text = product.Name;
            ProductslistView.SelectedItems[0].SubItems[2].Text = product.Price;
            ProductslistView.SelectedItems[0].SubItems[3].Text = product.Date.ToString("dd/MM/yyyy");
            ProductslistView.SelectedItems[0].SubItems[4].Text = product.Category;
        }
        // button edit
        private void EditsimpleButton_Click(object sender, EventArgs e)
        {
            actionButton = FUNCTION_EDIT;

            for (int i = 0; i < ProductslistView.Items.Count; i++)
            {
                if (ProductslistView.Items[i].Selected)
                {
                    ProductDetail productDetailForm = new ProductDetail();
                    if (CheckExistForm("ProductDetail") == false)
                    {
                        GetInfomationProduct(i);
                        productDetailForm.editProducts = new ProductDetail.EditProducts(EditProductToListView);
                        productDetailForm.Show();
                    }
                    else
                    {
                        ActiveChildForm("ProductDetail");
                    }
                }
            }
        }
        // button delete
        private void DeletesimpleButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProductslistView.Items.Count; i++)
            {
                if (ProductslistView.Items[i].Selected)
                {
                    ProductslistView.Items.RemoveAt(i);
                }
            }
        }
    }
}