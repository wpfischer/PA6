using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitle.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenre.Text = myBook.genre;
                txtISBN.Text = myBook.isbn;
                txtCopiesAvlb.Text = myBook.copies.ToString();
                txtCover.Text = myBook.cover;
                txtLength.Text = myBook.length.ToString();

                pbCover.Load(myBook.cover);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitle.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenre.Text;
            myBook.isbn = txtISBN.Text;
            myBook.copies = int.Parse(txtCopiesAvlb.Text);
            myBook.cover = txtCover.Text;
            myBook.length = int.Parse(txtLength.Text);
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Context was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
