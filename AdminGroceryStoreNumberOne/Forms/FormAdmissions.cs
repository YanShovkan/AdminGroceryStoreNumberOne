using BusinessLogic.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne.Forms
{
    public partial class FormAdmissions : Form
    {
        MomentOfGoodsLogic momentOfGoodsLogic = new MomentOfGoodsLogic();
        public FormAdmissions()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var list = await momentOfGoodsLogic.GetAdmissions();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Form formProduct = new FormAdmission();
            if (formProduct.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormAdmission formAdmission = new FormAdmission();
                formAdmission.Id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if (formAdmission.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    try
                    {
                       await momentOfGoodsLogic.DeleteAdmission(id);

                        MessageBox.Show("Удаление прошло успешно", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
