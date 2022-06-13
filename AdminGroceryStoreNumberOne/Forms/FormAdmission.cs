using BusinessLogic.DataGridModels;
using BusinessLogic.Logic;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne.Forms
{
    public partial class FormAdmission : Form
    {
        ProductLogic productLogic = new ProductLogic();
        List<ProductModel> products = new List<ProductModel>();

        MomentOfGoodsLogic momentOfGoodsLogic = new MomentOfGoodsLogic();
        TablePartLogic tablePartLogic = new TablePartLogic();
        Dictionary<string, (string, int)> tableParts = new Dictionary<string, (string, int)>();
        List<string> oldTablePartsId = new List<string>();

        public string Id { set { id = value; } }
        private string id;
        public FormAdmission()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                if (tableParts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var tablePart in tableParts)
                    {
                        dataGridView.Rows.Add(new object[] { tablePart.Key, tablePart.Value.Item1,
                            tablePart.Value.Item2 });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddTablePart formAddTablePart = new FormAddTablePart();
            if (formAddTablePart.ShowDialog() == DialogResult.OK)
            {
                if (tableParts.ContainsKey(formAddTablePart.productId))
                {
                    tableParts[formAddTablePart.productId] = (products.FirstOrDefault(p => p.id.Equals(formAddTablePart.productId)).name, formAddTablePart.count);
                }
                else
                {
                    tableParts.Add(formAddTablePart.productId, (products.FirstOrDefault(p => p.id.Equals(formAddTablePart.productId)).name, formAddTablePart.count));
                }
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormAddTablePart formAddTablePart = new FormAddTablePart();
                string productId = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                formAddTablePart.productId = productId;
                formAddTablePart.count = tableParts[productId].Item2;
                if (formAddTablePart.ShowDialog() == DialogResult.OK)
                {
                    tableParts[formAddTablePart.productId] = (products.FirstOrDefault(p => p.id.Equals(formAddTablePart.productId)).name, formAddTablePart.count);
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    try
                    {
                        tableParts.Remove(Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            if (tableParts.Count < 1)
            {
                MessageBox.Show("Поступление должно содержать хотя бы один товар", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Вы не можете оформить поставку в будущем!!!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    await momentOfGoodsLogic.AddAdmission(new MovementOfGoodModel { 
                        date = dateTimePicker.Value.ToShortDateString(),
                        type = "поступление"
                    });

                    MovementOfGoodsDataGridModel admission = await momentOfGoodsLogic.GetEmptyAdmission();

                    foreach(var tablePart in tableParts)
                    {
                        await tablePartLogic.AddTablePart(new TablePartModel
                        {
                            movmentOfGoodId = admission.id,
                            productId = tablePart.Key,
                            count = tablePart.Value.Item2
                        });
                    }
                }
                else {
                    await momentOfGoodsLogic.UpdateAdmission(new MovementOfGoodModel
                    {
                        id = id,
                        date = dateTimePicker.Value.ToShortDateString(),
                        type = "поступление"
                    });

                    foreach (String tableId in oldTablePartsId)
                    {
                        await tablePartLogic.DeleteTablePart(tableId);
                    }

                    foreach (var tablePart in tableParts)
                    {
                        await tablePartLogic.AddTablePart(new TablePartModel
                        {
                            movmentOfGoodId = id,
                            productId = tablePart.Key,
                            count = tablePart.Value.Item2
                        });
                    }
                }

                MessageBox.Show("Добавление продукта прошло успешно", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void FormAdmission_Load(object sender, EventArgs e)
        {
            products = await productLogic.GetAllProducts();

            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    
                    MovementOfGoodsDataGridModel view = await momentOfGoodsLogic.GetAdmissionById(id);

                    dateTimePicker.Value = new DateTime(Convert.ToInt32(view.date.Split('.')[2]), Convert.ToInt32(view.date.Split('.')[1]), Convert.ToInt32(view.date.Split('.')[0]));

                    if (view != null)
                    {
                        foreach (TablePartModel tablePart in view.tableParts)
                        {
                            tableParts.Add(tablePart.productId, (products.FirstOrDefault(p => p.id.Equals(tablePart.productId)).name, tablePart.count));
                            oldTablePartsId.Add(tablePart.id);
                        }

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}
