using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20170810_3Win_Listeleyiciler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        /*
         * Listboxta birden fazla eleman seçebilmek için SelectionMode MultiSimple veya MultiExtend olarak seçilmelidir.
         * MultiSimple seçildiğinde ctrl tuşuna basmaya gerek kalmadan birden fazla seçim yapılabilir.
         * MultiExtend seçildiğinde birden fazla seçim yapabilmek için Ctrl tuşuna basılı tutarak tıklama yapmak gerekir. ikinci bir seçim yolu olarak ise fareye basılı tutarak seçim yapmak tercih edilebilir.
        */

        private void button1_Click(object sender, EventArgs e)
        {
            // listBox1.Items.Add(); kullanarak en son eklenen elemanın en alta gelmesi sağlanabilir.
            // eğer son eklenen elemanın en üste gelmesi isteniyorsa listBox1.Items.Insert(0, textBox1.Text); şeklinde bir kullanım ile Insert metotu kullanılabilmektedir.

            listBox1.Items.Insert(0,textBox1.Text);
            
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             * Remove metodu tekli olarak silme işlemi yapabilmektedir.
             * tek seferde  birden fazla silme yapabilmek için foreach döngüsü kullanılarak listBox1.SelectedItems collectionundan gelen her bir eleman için remove metodu çağrılır. ANCAK bu işlemi yaparken her seferinde listbox un selecteditems collectionunun içeriği değişeceği için hata verecektir. Bunu çözebilmek için önceden oluşturduğumuz bir silinecekler dizisinden yararlanarak bypass edebiliriz.
             * Çoklu silme işlemi için illaki birden fazla seçim yapılmasına gerek yoktur. Tek seçim yapıldığında da kullanılabilir.
             * HorizontalScrollbar : listboxa çok uzun bir değer girilirse alttan yatay scroll bar çıksın ve o değer görüntülenebilsin isteniyorsa aktif edilmesi gereken listbox özelliğidir.
             * 
             * Herhangi bir elemanın üzerinde klavyeden tuş göndererek işlem yapılmak isteniyorsa. elemanın properties penceresinden event kısmı açılır ve KeyDown eventi çağrılır. sonrasında yapılmak istenen işlemin kodları yazılır. burada e.KeyCode olarak yakalanan tuşların kontrolu yapılarak hangi tuş için işlem yapılacaksa onun tespit edilmesi gerekmektedir. Bunun için;
             * if(e.KeyCode == Keys.Delete) gibi bir kontrol yapmak mümkündür.
             */

            // çoklu silme 
            string[] silinecekler = new string[listBox1.SelectedItems.Count];
            for (int i = 0; i < silinecekler.Length; i++)
            {
                silinecekler[i] = listBox1.SelectedItems[i].ToString();
            }

            foreach (string eleman in silinecekler)
            {
                listBox1.Items.Remove(eleman);
            }

           // tekli silme 
           // listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string[] silinecekler = new string[listBox1.SelectedItems.Count];
                for (int i = 0; i < silinecekler.Length; i++)
                {
                    silinecekler[i] = listBox1.SelectedItems[i].ToString();
                }

                foreach (string eleman in silinecekler)
                {
                    listBox1.Items.Remove(eleman);
                }
            }
        }
    }
}
