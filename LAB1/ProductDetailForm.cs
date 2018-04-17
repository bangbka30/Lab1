using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LAB1
{
    public partial class ProductDetail : DevExpress.XtraEditors.XtraForm
    {
        public ProductDetail()
        {
            InitializeComponent();
        }
        int actionButton;
        Products product;
        List<string> listCode;
        List<string> listCategory;
        // khởi tạo deleget thêm sản phẩm
        public delegate void AddProducts(Products product);
        public AddProducts addProducts;
        // khởi tạo deleget sửa sản phẩm
        public delegate void EditProducts(Products product);
        public EditProducts editProducts;
        private void CreateListCategory()
        {
            listCategory = new List<string>();
            listCategory.Add("Sony");
            listCategory.Add("SamSung");
            listCategory.Add("Iphone");
            listCategory.Add("LG");
            listCategory.Add("Oppo");
            listCategory.Add("Vivo");
        }
        private void ReceiveListCode()
        {
            listCode = new List<string>();
            listCode = ProductListForm.listCodeProducts;
        }
        private void ReceiveProduct()
        {
            product = new Products();
            product = ProductListForm.product;
            CodetextBox.Text = product.Code;
            NametextBox.Text = product.Name;
            PricetextBox.Text = product.Price;
            DateTimePicker.Value = product.Date;
            CategorycomboBox.Text = product.Category;
        }
        private void LoadForm()
        {
            actionButton = ProductListForm.actionButton;
            if (actionButton == 1)
            {
                ReceiveListCode();
            }
            if (actionButton == 2)
            {
                CodetextBox.ReadOnly = true;
                ReceiveProduct();
            }
            CreateListCategory();
            foreach (string itemCategory in listCategory)
            {
                CategorycomboBox.Items.Add(itemCategory);
            }
        }
        private void ProductDetail_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private bool CheckExisteProducts()
        {
            bool checkExist = false;
            foreach (string item in listCode)
            {
                if (item == CodetextBox.Text)
                {
                    checkExist = true;
                    break;
                }
            }
            return checkExist;
        }
        // button Save
        private void SavesimpleButton_Click(object sender, EventArgs e)
        {
            if (CategorycomboBox.Text == "" || CodetextBox.Text == "" || NametextBox.Text == "" || PricetextBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (actionButton == 1)
                {
                    bool check = CheckExisteProducts();
                    if (check == true)
                    {
                        MessageBox.Show("Sản Phẩm Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Products product = new Products();
                        product.Code = CodetextBox.Text;
                        product.Name = NametextBox.Text;
                        product.Price = PricetextBox.Text;
                        product.Date = DateTimePicker.Value;
                        product.Category = CategorycomboBox.Text;
                        addProducts(product);
                        this.Close();
                    }
                }
                else if (actionButton == 2)
                {
                    Products product = new Products();
                    product.Name = NametextBox.Text;
                    product.Price = PricetextBox.Text;
                    product.Date = DateTimePicker.Value;
                    product.Category = CategorycomboBox.Text;
                    editProducts(product);
                    this.Close();
                }
            }
        }

        private void CancelsimpleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PricetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}