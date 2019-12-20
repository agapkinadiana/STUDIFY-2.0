using Microsoft.Win32;
using STUDENT_GUI.DB;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace STUDENT_GUI.ViewModel
{
    class StudentInfoViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        EFStudentRepository eFStudent = new EFStudentRepository();

        int cardNumber, course, group, subgroup;
        string name, login, faculty, profession, bitmapImage = "";

        BitmapImage bitmap = new BitmapImage();

        Image i;
        public Image Image
        {
            get { return i; }
            set
            {
                i = value;
            }
        }

        public BitmapImage BitmapImage
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
            }
        }

        public StudentInfoViewModel()
        {
            cardNumber = currentStudent.ID;
            name = currentStudent.STUDENT_NAME;
            login = currentStudent.LOGIN;
            faculty = currentStudent.GROUP.FACULTY.FACULTY_NAME;
            profession = currentStudent.GROUP.PROFESSION.PROFESSION_NAME;
            course = currentStudent.GROUP.COURSE;
            group = currentStudent.GROUP.GROUP_NUMBER;
            subgroup = currentStudent.SUBGROUP.SUBGROUP_NUMBER;
            BitmapImage = LoadPhoto();
        }

        public BitmapImage LoadPhoto()
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (currentStudent.PHOTO != null)
            {
                using (var ms = new MemoryStream(currentStudent.PHOTO))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                }
            }
            return bitmapImage;
        }

        public void LoadImageFromFS()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|Png (*.png)|*.png";
            if (open.ShowDialog() == true)
            {
                string fileName = open.FileName;
                if (File.Exists(fileName))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        byte[] image = new byte[fs.Length];
                        fs.Read(image, 0, image.Length);
                        eFStudent.SetPhoto(currentStudent.ID, image);
                        currentStudent.PHOTO = image;
                        BitmapImage = LoadPhoto();
                    }
                }
            }
            else return;
        }

        public int CardNum
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public int Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Subgroup
        {
            get { return subgroup; }
            set { subgroup = value; }
        }
    }
}
