using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antivirus
{
    public partial class DeletingForm : Form
    {
        private List<string> malwares = new List<string>();
        public DeletingForm(List<string> vir)
        {
            InitializeComponent();
            foreach (var v in vir)
                malwares.Add(v);
            foreach (var mal in malwares)
                checkedListBox.Items.Add(mal);
        }

        private void delSelectedBtn_Click(object sender, EventArgs e)
        {
            if (checkedListBox.CheckedItems.Count > 0)
            {
                
                for(int i = checkedListBox.Items.Count - 1; i >= 0; i--)
                {
                    if (checkedListBox.GetItemChecked(i))
                    {
                        try
                        {
                            File.Delete(checkedListBox.Items[i].ToString());
                            checkedListBox.Items.Remove(checkedListBox.Items[i]);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                var result = MessageBox.Show("Все выбранные файлы были удалены!\n" + "Хотите удалить ещё что-то из списка заражённых файлов?", "Успех!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                /*
                foreach (var item in checkedListBox.CheckedItems)
                {
                    
                    try
                    {
                        File.Delete(item.ToString());
                        checkedListBox.Items.Remove(item);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                var result = MessageBox.Show("Все выбранные файлы были удалены!\n" + "Хотите удалить ещё что-то из списка заражённых файлов?", "Успех!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    this.Close();
                }*/
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одного файла!", "Ошибка удаления!");
            }    
        }

        private void delAllBtn_Click(object sender, EventArgs e)
        {
            if (checkedListBox.Items.Count > 0)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    try
                    {
                        File.Delete(checkedListBox.Items[i].ToString());
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                checkedListBox.Items.Clear();
                var result = MessageBox.Show("Все заражённые файлы из этой директории удалены!", "Успех!");
                if (result == DialogResult.OK)
                    this.Close();
                /*
                foreach (var item in checkedListBox.Items)
                {
                    try
                    {                        
                        File.Delete(item.ToString());
                        checkedListBox.Items.Remove(item);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                var result = MessageBox.Show("Все заражённые файлы из этой директории удалены!", "Успех!");
                if (result == DialogResult.OK)
                    this.Close();
                */
            }
            else
            {
                MessageBox.Show("Нечего удалять!");
            }    
        }
    }
}
