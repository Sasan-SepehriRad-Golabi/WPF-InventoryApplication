using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using InventoryApplication.DataAccess;
using InventoryApplication.ViewModels.Commands;
using InventoryApplication.Views;

namespace InventoryApplication.ViewModels
{
    public class RegisterNewMaterialViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FilterInfoCollection filterInfoCollection;
        public VideoCaptureDevice videoCaptureDevice { get; set; }
        public bool _DialogHostVisibility3;
        public bool DialogHostVisibility3
        {
            get
            {
                return _DialogHostVisibility3;
            }
            set
            {
                _DialogHostVisibility3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DialogHostVisibility3"));
            }
        }
        public bool _DialogHostVisibility2;
        public bool DialogHostVisibility2
        {
            get
            {
                return _DialogHostVisibility2;
            }
            set
            {
                _DialogHostVisibility2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DialogHostVisibility2"));
            }
        }
        public bool _DialogHostVisibility;
        public bool DialogHostVisibility
        {
            get
            {
                return _DialogHostVisibility;
            }
            set
            {
                _DialogHostVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DialogHostVisibility"));
            }
        }
        public bool _DialogHostVisibility1;
        public bool DialogHostVisibility1
        {
            get
            {
                return _DialogHostVisibility1;
            }
            set
            {
                _DialogHostVisibility1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DialogHostVisibility1"));
            }
        }
        public InventoryApplicationContext ctx { get; set; }
        public RegisterNewMaterialView MyView { get; set; }
        private List<Models.Material> _NamesofMaterials;

        public List<Models.Material> NamesofMaterials
        {
            get { return _NamesofMaterials; }
            set { _NamesofMaterials = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NamesofMaterials")); }
        }
        private ObservableCollection<Models.Material> _NamesofMaterialsob;

        public ObservableCollection<Models.Material> NamesofMaterialsob
        {
            get { return _NamesofMaterialsob; }
            set { _NamesofMaterialsob = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NamesofMaterialsob")); }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _MainMessageQueue_personel;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MainMessageQueue_personel
        {
            get { return _MainMessageQueue_personel; }
            set
            {
                _MainMessageQueue_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainMessageQueue_personel"));
            }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _MainMessageQueue;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MainMessageQueue
        {
            get { return _MainMessageQueue; }
            set
            {
                _MainMessageQueue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainMessageQueue"));
            }
        }
        private bool _MainSnackIsActive_personel;
        public bool MainSnackIsActive_personel
        {
            get { return _MainSnackIsActive_personel; }
            set
            {
                _MainSnackIsActive_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainSnackIsActive_personel"));
            }
        }
        private bool _MainSnackIsActive;
        public bool MainSnackIsActive
        {
            get { return _MainSnackIsActive; }
            set
            {
                _MainSnackIsActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainSnackIsActive"));
            }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _CompanyMessageQueue;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue CompanyMessageQueue
        {
            get { return _CompanyMessageQueue; }
            set
            {
                _CompanyMessageQueue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompanyMessageQueue"));
            }
        }
        private bool _CompanySnackIsActive;
        public bool CompanySnackIsActive
        {
            get { return _CompanySnackIsActive; }
            set
            {
                _CompanySnackIsActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompanySnackIsActive"));
            }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _StoreMessageQueue;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue StoreMessageQueue
        {
            get { return _StoreMessageQueue; }
            set
            {
                _StoreMessageQueue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StoreMessageQueue"));
            }
        }
        private bool _StoreSnackIsActive;
        public bool StoreSnackIsActive
        {
            get { return _StoreSnackIsActive; }
            set
            {
                _StoreSnackIsActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StoreSnackIsActive"));
            }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _PersonelMessageQueue;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue PersonelMessageQueue
        {
            get { return _PersonelMessageQueue; }
            set
            {
                _PersonelMessageQueue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonelMessageQueue"));
            }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _ReceiptMessageQueue;
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue ReceiptMessageQueue
        {
            get { return _ReceiptMessageQueue;}
            set
            {
                _ReceiptMessageQueue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptMessageQueue"));
            }
        }
        private bool _ReceiptSnackIsActive;
        public bool ReceiptSnackIsActive
        {
            get { return _ReceiptSnackIsActive; }
            set
            {
                _ReceiptSnackIsActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptSnackIsActive"));
            }
        }
        private Models.Receipt _MaterialReceipt;

        public Models.Receipt MaterialReceipt
        {
            get { return _MaterialReceipt; }
            set { _MaterialReceipt = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialReceipt")); }
        }

        public RegisterNewMaterialViewModel(RegisterNewMaterialView vm)
        {
            ctx = new InventoryApplicationContext();
            MyView = vm;
            NamesofMaterials = new List<Models.Material>();
            NamesofMaterialsob = getNamesofMaterials(null);
            MyWebCamImage = new BitmapImage();
            MyWebCamImage_person = new BitmapImage();
            MyImageSourceVisibility_1 = "Visible";
            MyImageSourceVisibility0 = "Hidden"; 
             MyImageSourceVisibility2 = "Hidden";
            MyImageSourceVisibility1 = "Hidden";
            MyImageSourceVisibility_1_personel = "Hidden";
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility1_personel = "Hidden";
            MainMessageQueue_personel = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            DialogHostVisibility = false;
            NewMaterial = new Models.Material();
            NewPersonel = new Models.Peronel();
            using (MemoryStream memory = new MemoryStream())
            {
                //File.OpenRead(filepath).CopyTo(memory);
                //memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.UriSource = new Uri(@"pack://application:,,,/InventoryApplication;component/Assets/Images/unknown.png");
                //bitmapimage.StreamSource = memory;
                //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                //bitmapimage.Freeze();
                MyResultImage = bitmapimage;
                NewMaterial.MaterialImage = ConvertToByte(MyResultImage);
            }
            ListofWebcams = new ObservableCollection<string>();
            ListofWebcams.Add("لیست وب کم ها");
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in filterInfoCollection)
            {
                ListofWebcams.Add(fi.Name);
            }
            MyGetPictureFromWebComCommand = new Commands.GetPictureFromWebCam(this);
            MyPersonelGetPictureFromWebComCommand = new Commands.GetPictureFromWebCamPersonel(this);
            MyCommandTest = new Commands.MyCommandTest(this);
            MyCancelDialogReceipt = new Commands.CancelDialogReceipt(this);
            MyCancelDialogPersonel = new Commands.CancelDialogPersonel(this);
            MyCommandTestRegisterStore = new Commands.MyCommandTestRegisterStore(this);
            RegisterNewMaterialCommand = new Commands.RegisterNewMaterialCommand(this);
            RegisterNewMaterialCommandRecipt = new Commands.MyCommandTestReceipt(this);
            RegisterNewMaterialCommandPersonel = new Commands.MyCommandTestPersonel(this);
            MyRegisterNewPersonelCommand = new Commands.RegisterNewPersonelCommand(this);
            ErrorCollection = new Dictionary<string, string>();
            (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
            NameofPersonels =new ObservableCollection<Models.Peronel>(getNameofPersonels());
            MaterialInventory = new Models.Inventory();
            MaterialCompany = new Models.ProviderCompany();
            MaterialReceipt = new Models.Receipt();
            MainMessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            CompanyMessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            ReceiptMessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            StoreMessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
        }
        public bool RegisterNewPersonelCommandCanExecute()
        {
            try
            {
                if (NewPersonel != null && (NewPersonel.Company != null && NewPersonel.Company.Length > 0 && NewPersonel.Company.Length < 13) &&
               (NewPersonel.FirstName != null && NewPersonel.FirstName.Length > 0 && NewPersonel.FirstName.Length < 13) &&
               (NewPersonel.LastName != null && NewPersonel.LastName.Length > 0 && NewPersonel.LastName.Length < 13) &&
               NewPersonel.correctpersonelynumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private ObservableCollection<Models.Peronel> _NameofPersonels;

        public ObservableCollection<Models.Peronel> NameofPersonels
        {
            get { return _NameofPersonels; }
            set { _NameofPersonels = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels")); }
        }

        public IEnumerable<Models.Peronel> getNameofPersonels()
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            List<Models.Peronel> persons = uni.MyPersonRep.GetAll().ToList();
            return persons;
        }
        public void RegisterNewPersonelCommandExecute()
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                uni.MyPersonRep.Add(NewPersonel);
                uni.complete();
                NameofPersonels = new ObservableCollection<Models.Peronel>(getNameofPersonels());
                MainMessageQueue_personel.Enqueue("اطلاعات ثبت گردید");
                MainSnackIsActive_personel = true;
                ctx.Entry(NewPersonel).State = System.Data.Entity.EntityState.Detached;
                NewPersonel.Company = ""; NewPersonel.FirstName = ""; NewPersonel.LastName = "";
                NewPersonel.JobTitle = ""; NewPersonel.OtherPoints = ""; NewPersonel.PersonelImage = null;
                NewPersonel.PersonelyNumber = ""; NewPersonel.correctpersonelynumber = false;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public class AbstractMaterial
        {
            public virtual string ToString()
            {
                return Name;
            }
            public string Name { get; set; }
            public byte[] MaterialImage { get; set; }
        }
        public ObservableCollection<Models.Material> getNamesofMaterials(string tt)
        {
            InventoryApplicationContext ctx1 = new InventoryApplicationContext();
            try
            {
                UnitOfWork myunit = new UnitOfWork(ctx1);
                if (string.IsNullOrEmpty(tt))
                {
                    var yy = from b in myunit.MyMaterialsRep.GetAll().Where(x=>x.NumberofMaterial!="-45") group b by b.Name into newout select newout;
                    NamesofMaterials.Clear();
                    foreach (var x in yy)
                    {
                        foreach (var x1 in x)
                        {
                            NamesofMaterials.Add(x1);
                            break;
                        }
                    }
                    ctx1.Dispose();
                    ctx1 = null;
                    return new ObservableCollection<Models.Material>(NamesofMaterials);

                }
                else
                {
                    var yy = from b in myunit.MyMaterialsRep.find(x => x.Name.Contains(tt)).Where(x=>x.NumberofMaterial!="-45") group b by b.Name into newout select newout;
                    NamesofMaterials.Clear();
                    foreach (var x in yy)
                    {
                        foreach (var x1 in x)
                        {
                            NamesofMaterials.Add(x1);
                            break;
                        }
                    }
                }
                ctx1.Dispose();
                ctx1 = null;
                return new ObservableCollection<Models.Material>(NamesofMaterials);
            }
            catch(Exception ex)
            {
                ctx1.Dispose();
                ctx1 = null;
                return null;
            }
        }
        public (ObservableCollection<Models.Inventory>, ObservableCollection<Models.ProviderCompany>) getNameofStoresandcompanies()
        {

            try
            {
                ObservableCollection<Models.Inventory> mylistofstores = new ObservableCollection<Models.Inventory>();
                ObservableCollection<Models.ProviderCompany> mylistofcompanies = new ObservableCollection<Models.ProviderCompany>();
                UnitOfWork uw = new UnitOfWork(ctx);
                mylistofstores = new ObservableCollection<Models.Inventory>(uw.MyInventoriesRep.GetAll());
                mylistofcompanies = new ObservableCollection<Models.ProviderCompany>(uw.MyProviderCompaniesRep.GetAll());
                return (mylistofstores, mylistofcompanies);
            }
            catch(Exception ex)
            {
                return (null,null);
            }
        }

        public ICommand MyPersonelGetPictureFromWebComCommand { get; set; }
        public ICommand MyRegisterNewPersonelCommand { get; set; }
        public ICommand MyCommandTestRegisterStore { get; set; }
        public ICommand MyCancelDialogReceipt { get; set; }
        public ICommand MyCancelDialogPersonel { get; set; }
        public ICommand RegisterNewMaterialCommand { get; set; }
        public ICommand RegisterNewMaterialCommandRecipt { get; set; }
        public ICommand RegisterNewMaterialCommandPersonel { get; set; }
        public ICommand MyGetPictureFromWebComCommand { get; set; }
        public ICommand MyCommandTest { get; set; }
        private string _NewNumberofMaterial;

        public string NewNumberofMaterial
        {
            get { return _NewNumberofMaterial; }
            set 
            {
                _NewNumberofMaterial = value;
                NewMaterial.NumberofMaterial = value;
                int res;
                if(int.TryParse(value,out res))
                {
                    NumofExistingMAterial = myprivatetotalnum + res;
                }
                else
                {
                    NumofExistingMAterial = myprivatetotalnum;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewNumberofMaterial"));
            }
        }

        private int _NumofExistingMAterial;

        public int NumofExistingMAterial
        {
            get { return _NumofExistingMAterial; }
            set { _NumofExistingMAterial = value;
                NewMaterial.RemainedNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumofExistingMAterial")); }
        }
        private int myprivatetotalnum;
        private string _NewMaterialltext;

        public string NewMaterialltext
        {
            get { return _NewMaterialltext; }
            set 
            { 
                _NewMaterialltext = value;
                if (value != null && !string.IsNullOrEmpty(value) && value.Length > 0)
                {
                    UnitOfWork un = new UnitOfWork(ctx);
                    IEnumerable<Models.Material> matss = un.MyMaterialsRep.find(x => x.Name == value).Where(x=>x.NumberofMaterial!="-45");
                    foreach (Models.Material mat in matss)
                    {
                        ctx.Entry(mat).Reload();
                    }
                        int tt = 0;
                    foreach(Models.Material mat in un.MyMaterialsRep.find(x => x.Name == value).Where(x => x.NumberofMaterial != "-45"))
                    {
                        int rr=0;
                        if(int.TryParse(mat.NumberofMaterial,out rr))
                        {
                            tt = tt +rr;
                        }
                        else
                        {
                            tt = tt + 0;
                        }
                       
                    }
                  
                    NumofExistingMAterial = tt;
                    myprivatetotalnum = NumofExistingMAterial;
                    NewMaterial.RemainedNumber = NumofExistingMAterial;
                    //NamesofMaterialsob = getNamesofMaterials(null);
                    NewMaterial.Name = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewMaterialltext")); }
        }

        private Models.Material _NewMaterial;
        public Models.Material NewMaterial
        {
            get
            {
                return _NewMaterial;
            }
            set
            {
                
                _NewMaterial = value;
                 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewMaterial"));
            }
        }
        private string _ReceiptNumber;

        public string ReceiptNumber 
        {
            get { return _ReceiptNumber; }
            set 
            { 
                _ReceiptNumber = value;
                NewMaterial.MaterialReceiptnumber = value;
                MaterialReceipt.ReceiptNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptNumber")); }
        }
        private Models.Inventory _MaterialInventory;

        public Models.Inventory MaterialInventory
        {
            get { return _MaterialInventory; }
            set 
            { 
                _MaterialInventory = value;
                if(NewMaterial!=null && value != null)
                {
                    NewMaterial.MaterialInventoryid = ((Models.Inventory)value).Id;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialInventory"));
            }
        }

        private Models.ProviderCompany _MaterialCompany;

        public Models.ProviderCompany MaterialCompany
        {
            get { return _MaterialCompany; }
            set 
            { 
                _MaterialCompany = value;
                if (NewMaterial != null && value!=null)
                {
                    NewMaterial.MaterialCompanyid = ((Models.ProviderCompany)value).Id;
                }
                if (MaterialReceipt != null && value!=null)
                {
                    MaterialReceipt.TheProviderCompanyid= ((Models.ProviderCompany)value).Id; 
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialCompany"));
            }
        }


        public bool ProperReceiptNumber { get; set; } = false;
        public bool ProperMyReceiptNumber { get; set; } = false;
        public bool ProperIssuer { get; set; } = false;
        public bool ProperCostValue{ get; set; } = false;
        public bool ProperDateofBuying { get; set; } = false;
 

        private BitmapImage _MyWebCamImage;

        public BitmapImage MyWebCamImage
        {
            get { return _MyWebCamImage; }
            set
            {
                _MyWebCamImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyWebCamImage"));
            }
        }
        private BitmapImage _MyWebCamImage_person;

        public BitmapImage MyWebCamImage_person
        {
            get { return _MyWebCamImage_person; }
            set { _MyWebCamImage_person = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyWebCamImage_person")); }
        }

        private BitmapImage _MyResultImage;

        public BitmapImage MyResultImage
        {
            get { return _MyResultImage; }
            set
            {
                _MyResultImage = value;
                if (NewMaterial != null)
                {
                    NewMaterial.MaterialImage = ConvertToByte(_MyResultImage);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyResultImage"));
            }
        }

        private BitmapImage _MyResultImage_personel;

        public BitmapImage MyResultImage_personel
        {
            get { return _MyResultImage_personel; }
            set
            {
                _MyResultImage_personel = value;
                if (NewPersonel != null)
                {
                    NewPersonel.PersonelImage = ConvertToByte(_MyResultImage_personel);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyResultImage_personel"));
            }
        }

        private int _MyWebCamSelectedIndex;

        public int MyWebCamSelectedIndex
        {
            get { return _MyWebCamSelectedIndex; }
            set
            {
                if (value != 0)
                {
                    _MyWebCamSelectedIndex = value;
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[value - 1].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                }
            }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                    bitmapimage.Freeze();
                    MyWebCamImage = bitmapimage;
                    MyWebCamImage_person = bitmapimage;
                }
            }
            catch(Exception ex)
            {

            }
        }
        public byte[] ConvertToByte(BitmapImage img)
        {
            byte[] data;
            try
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                    return data;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        
        private ObservableCollection<Models.ProviderCompany> _ListofCompanies;
        public ObservableCollection<Models.ProviderCompany> ListofCompanies
        {
            get
            {
                return _ListofCompanies;
            }
            set
            {
                _ListofCompanies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListofCompanies"));
            }
        }
        public ObservableCollection<String> ListofWebcams { get; set; }
        private ObservableCollection<Models.Inventory> _NameOFStores;
        public ObservableCollection<Models.Inventory> NameOFStores {
            get
            {
                return _NameOFStores;
            }
            set
            {
                _NameOFStores = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameOFStores"));
            }
        }
        private string _MyImageSourceVisibility_1;

        public string MyImageSourceVisibility_1
        {
            get { return _MyImageSourceVisibility_1; }
            set { _MyImageSourceVisibility_1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1")); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1")); }
        }
        private string _MyImageSourceVisibility0;

        public string MyImageSourceVisibility0
        {
            get { return _MyImageSourceVisibility0; }
            set { _MyImageSourceVisibility0 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1")); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0")); }
        }
        private string _MyImageSourceVisibility1;

        public string MyImageSourceVisibility1
        {
            get { return _MyImageSourceVisibility1; }
            set { _MyImageSourceVisibility1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1")); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2")); }
        }
        private string _MyImageSourceVisibility2;

        public string MyImageSourceVisibility2
        {
            get { return _MyImageSourceVisibility2; }
            set { _MyImageSourceVisibility2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2")); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1")); }
        }

        private int _MySelectedImgeSources;

        public int MySelectedImgeSources
        {
            get { return _MySelectedImgeSources; }
            set
            {
                _MySelectedImgeSources = value;
                if (value == 0)
                {
                    MyImageSourceVisibility2 = "Hidden";
                    MyImageSourceVisibility0 = "Hidden";
                    MyImageSourceVisibility1 = "Hidden";
                    MyImageSourceVisibility_1 = "Visible";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknown.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknown.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        //bitmapimage.Freeze();
                        MyResultImage = bitmapimage;
                    }
                }
                else if (value == 1)
                {
                    MyImageSourceVisibility2 = "Hidden";
                    MyImageSourceVisibility0 = "Visible";
                    MyImageSourceVisibility1 = "Hidden";
                    MyImageSourceVisibility_1 = "Hidden";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknownmaterial.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknownmaterial.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        //bitmapimage.Freeze();
                        MyResultImage = bitmapimage;
                    }
                }
                else if (value == 2)
                {
                    MyImageSourceVisibility_1 = "Hidden";
                    MyImageSourceVisibility2 = "Hidden";
                    MyImageSourceVisibility0 = "Hidden";
                    MyImageSourceVisibility1 = "Visible";
                }
                else if(value>2)
                {
                    MyImageSourceVisibility_1 = "Hidden";
                    MyImageSourceVisibility2 = "Visible";
                    MyImageSourceVisibility1 = "Hidden";
                    MyImageSourceVisibility0 = "Hidden";
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MySelectedImgeSources"));
            }
        }


        private string _MyImageSourceVisibility_1_personel;

        public string MyImageSourceVisibility_1_personel
        {
            get { return _MyImageSourceVisibility_1_personel; }
            set { _MyImageSourceVisibility_1_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility0_personel;

        public string MyImageSourceVisibility0_personel
        {
            get { return _MyImageSourceVisibility0_personel; }
            set { _MyImageSourceVisibility0_personel = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel")); 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility1_personel;

        public string MyImageSourceVisibility1_personel
        {
            get { return _MyImageSourceVisibility1_personel; }
            set { _MyImageSourceVisibility1_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility2_personel;

        public string MyImageSourceVisibility2_personel
        {
            get { return _MyImageSourceVisibility2_personel; }
            set { _MyImageSourceVisibility2_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }

        private int _MySelectedImgeSourcesPersonel;

        public int MySelectedImgeSourcesPersonel
        {
            get { return _MySelectedImgeSourcesPersonel; }
            set
            {
                _MySelectedImgeSourcesPersonel = value;
                if (value == 0)
                {
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                    MyImageSourceVisibility1_personel = "Hidden";
                    MyImageSourceVisibility_1_personel = "Visible";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknownman.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknownman.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        //bitmapimage.Freeze();
                        MyResultImage_personel = bitmapimage;
                    }
                }
                else if (value == 1)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Visible";
                    MyImageSourceVisibility1_personel = "Hidden";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknownman.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknownman.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        //bitmapimage.Freeze();
                        MyResultImage_personel = bitmapimage;
                    }
                }
                else if (value == 2)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                    MyImageSourceVisibility1_personel = "Visible";
                }
                else if (value > 2)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Visible";
                    MyImageSourceVisibility1_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MySelectedImgeSourcesPersonel"));
            }
        }

        private string _ReceiptSnackBarMessage;

        public string ReceiptSnackBarMessage
        {
            get { return _ReceiptSnackBarMessage; }
            set { _ReceiptSnackBarMessage = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptSnackBarMessage")); }
        }

        public string Error { get { return null; } }
        private Dictionary<string, string> _ErrorCollection;
        public Dictionary<string, string> ErrorCollection 
        {
            get
            {
                return _ErrorCollection;
            }
            set
            {
                _ErrorCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorCollection"));
            }
            }
        private Models.Peronel _NewPersonel;

        public Models.Peronel NewPersonel
        {
            get { return _NewPersonel; }
            set { _NewPersonel = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewPersonel")); }
        }
        private ObservableCollection<Models.Material> _ListofMaterials;

        public ObservableCollection<Models.Material> ListofMaterials
        {
            get { return _ListofMaterials; }
            set { _ListofMaterials = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListofMaterials")); }
        }

        public bool propermaterialviewmode { get; set; } = false;
        public bool propermaterialviewmode1 { get; set; } = false;
        public bool propermaterialviewmode2 { get; set; } = false;
        public string this[string name]
        {
           get
            {
                string errorresult = null;

                switch (name)
                {
                    case "ReceiptNumber":
                        if (string.IsNullOrEmpty(ReceiptNumber))
                        {
                            errorresult = "";
                            propermaterialviewmode = false;
                            propermaterialviewmode1 = false;
                        }
                        else
                        {
                            propermaterialviewmode = true;
                            propermaterialviewmode1 = true;
                            int res;
                            if (!int.TryParse(ReceiptNumber, out res))
                            {
                                errorresult = "فرمت صحیح نیست";
                                propermaterialviewmode = false;
                                propermaterialviewmode1 = false;
                            }
                            else
                            {
                                UnitOfWork myuni = new UnitOfWork(ctx);
                                propermaterialviewmode = true;
                                propermaterialviewmode1 = true;
                                int numofreceipts = myuni.MyReceiptsRep.find(x => x.ReceiptNumber == ReceiptNumber).Count();
                                if (numofreceipts<=0)
                                {
                                    errorresult = "شماره فاکتور جدید است. ";
                                    propermaterialviewmode1 = false;
                                    propermaterialviewmode = true;
                                }
                                else if (numofreceipts>1)
                                {
                                    errorresult = "شماره فاکتور تکراری است. ";
                                    propermaterialviewmode1 = false;
                                    propermaterialviewmode = false;
                                }
                                else
                                {
                                    propermaterialviewmode1 = true;
                                    propermaterialviewmode = true;
                                    errorresult = "";
                                }
                            }
                        }
                        break;
                    case "NewNumberofMaterial":
                        if (string.IsNullOrEmpty(NewNumberofMaterial))
                        {
                            errorresult = "";
                            propermaterialviewmode2 = false;
                        }
                        else
                        {
                            propermaterialviewmode2 = true;
                            int res;
                            if (!int.TryParse(NewNumberofMaterial, out res))
                            {
                                errorresult = "فرمت وارد شده صحیح نیست";
                                propermaterialviewmode2 = false;
                            }
                        }
                        break;
                    default:
                        break;
                }
         
                return errorresult;
            }
        }
        public BitmapImage GetPictureFromWebCamPersonel()
        {
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility1_personel = "Hidden";
            MyImageSourceVisibility_1_personel = "Hidden";
            MyResultImage_personel = MyWebCamImage_person;
            return MyResultImage_personel;
        }

        public BitmapImage GetPictureFromWebCam()
        {
            MyImageSourceVisibility2 = "Hidden";
            MyImageSourceVisibility0 = "Visible";
            MyImageSourceVisibility1 = "Hidden";
            MyImageSourceVisibility_1 = "Hidden";
            MyResultImage = MyWebCamImage;
            return MyResultImage;
        }

        public BitmapImage GetPictureFromDrop(BitmapImage img)
        {
            MyImageSourceVisibility2 = "Hidden";
            MyImageSourceVisibility0 = "Visible";
            MyImageSourceVisibility1 = "Hidden";
            MyImageSourceVisibility_1 = "Hidden";
            MyResultImage = img;
            return MyResultImage;
        }
        public BitmapImage GetPictureFromDropPersonel(BitmapImage img)
        {
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility1_personel = "Hidden";
            MyImageSourceVisibility_1_personel = "Hidden";
            MyResultImage_personel = img;
            return MyResultImage_personel;
        }
        public bool CanRegisterNewMaterial(object parm) 
        {
            if (parm == null || parm.GetType() != typeof(Models.Material))
            {
                return false;
            }
            else
            {
             Models.Material x = (Models.Material)parm;
                //if (propermaterialviewmode2 && propermaterialviewmode1  && x.ProperMaterial2 && x.ProperMaterial3 && x.ProperMaterial4 
                //       && (MyView.MaterialCompanyIdName.SelectedIndex>=0 && MaterialCompany!=null && MaterialCompany.NameofCompany!=null) && (MyView.MaterialInventoryIdName.SelectedIndex>=0 && MaterialInventory!=null && MaterialInventory.Name!=null)
                //       )
                //   {
                if (propermaterialviewmode2   && x.ProperMaterial4
                       && (MyView.MaterialInventoryIdName.SelectedIndex >= 0 && MaterialInventory != null && MaterialInventory.Name != null)
                       )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void RegisterNewMaterial(object parm)
        {
            try
            {
                UnitOfWork myunit = new UnitOfWork(ctx);
                var x = NewMaterial;
                NewMaterial.PrivateNumberofMaterial = NewMaterial.NumberofMaterial;
                IEnumerable<Models.Material> materials = myunit.MyMaterialsRep.find(y => y.Name == NewMaterial.Name).Where(xx=>xx.NumberofMaterial!="-45");
                foreach (Models.Material mat in materials)
                {
                    mat.RemainedNumber = NewMaterial.RemainedNumber;
                    mat.MinimumAcceptableDevices = NewMaterial.MinimumAcceptableDevices;
                    mat.MaterialImage = NewMaterial.MaterialImage;
                    myunit.MyMaterialsRep.Add(mat);
                    ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                }
                NewMaterial.PrivateNumberofMaterial = NewMaterial.NumberofMaterial;
                myunit.MyMaterialsRep.Add(NewMaterial);
                myunit.complete();
                ctx.Entry(NewMaterial).State = System.Data.Entity.EntityState.Detached;
                NewMaterial.DateofBuying = ""; NewMaterial.DateofDelivertoUser = "";
                NewMaterial.DateofEntrancetoStore = ""; NewMaterial.DateofExitofStore = "";
                NewMaterial.ICTSection = -1; NewMaterial.IfUsed = false;
                MyView.MaterialInventoryIdName.SelectedIndex = -1; MyView.MaterialCompanyIdName.SelectedIndex = -1;
                NewMaterial.InstalledLocation = ""; NewMaterial.IsAccessory = -1;
                NewMaterial.MaterialBarCode = ""; NewMaterial.MaterialCompanyid = -1;
                NewMaterial.MaterialInventoryid = -1; NewMaterial.MaterialReceiptnumber = "";
                ReceiptNumber = "";
                NewMaterial.MaterialRequester = ""; MyView.PersonelKeyUpname.SelectedIndex = -1;
                NewMaterialltext = ""; NewNumberofMaterial = ""; NumofExistingMAterial = 0;
                NewMaterial.MinimumAcceptableDevices = ""; NewMaterial.Name = ""; NewMaterial.notifyuser = false;
                NewMaterial.NumberofMaterial = ""; NewMaterial.RemainedNumber = -1; NewMaterial.PrivateNumberofMaterial = ""; NewMaterial.TimeofBuying = ""; NewMaterial.TimeofEntrancetoStore = "";
                NewMaterial.TimeofExitofStore = "";
                (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                NamesofMaterialsob = getNamesofMaterials(null);
                MainMessageQueue.Enqueue("اطلاعات با موفقیت ثبت گردید");
                MainSnackIsActive = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public bool CanExecuteCommandTest(object parm)
        {
            if ((string)parm == "1")
            {
                if (MaterialCompany!=null && MaterialCompany.ProperProviderCompany1 && MaterialCompany.ProperProviderCompany2
                    && MaterialCompany.ProperProviderCompany3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public void ExecuteCommandTest(object parm)
        {
            try
            {
                if ((string)parm == "1")
                {
                    UnitOfWork myunit = new UnitOfWork(ctx);
                    myunit.MyProviderCompaniesRep.Add(MaterialCompany);
                    myunit.complete();
                    ctx.Entry(MaterialCompany).State = System.Data.Entity.EntityState.Detached;
                    MaterialCompany.NameofCompany = "";
                    MaterialCompany.LocationAddress = "";
                    MaterialCompany.CallNumber = "";
                    MaterialCompany.FaxNumber = "";
                    MaterialCompany.Email = "";
                    MaterialCompany.Evaluation = 0;
                    //when i put unchanged here nothing happen in binding. 
                    //it is like unchanged roll back the variables to their previous values.
                    (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                    NamesofMaterialsob = getNamesofMaterials(null);
                    CompanyMessageQueue.Enqueue("اطلاعات با موفقیت ثبت شد");
                    CompanySnackIsActive = true;

                }
                else
                {
                    DialogHostVisibility = false;
                }
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        

        public bool CanExecuteCommandTestRegisterStore(object parm)
        {
            if ((string)parm == "1")
            {
                if(MaterialInventory!=null  && MaterialInventory.ProperInventory1 && MaterialInventory.ProperInventory2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public void ExecuteCommandTestRegisterStore(object parm)
        {
            try
            {
                if ((string)parm == "1")
                {
                    UnitOfWork myunit = new UnitOfWork(ctx);
                    myunit.MyInventoriesRep.Add(MaterialInventory);
                    myunit.complete();
                    ctx.Entry(MaterialInventory).State = System.Data.Entity.EntityState.Detached;
                    MaterialInventory.Name = ""; MaterialInventory.Location = "";
                    MaterialInventory.Accessors = "";
                    (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                    NamesofMaterialsob = getNamesofMaterials(null);
                    StoreMessageQueue.Enqueue("اطلاعات با موفقیت ثبت شد");
                    StoreSnackIsActive = true;
                }
                else
                {
                    DialogHostVisibility1 = false;
                }
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
            
        }
        public void MyCommandTestPersonel(object parm)
        {
            if ((string)parm == "1")
            {
                UnitOfWork myunit = new UnitOfWork(ctx);

                DialogHostVisibility3 = false;
            }
            else
            {
                DialogHostVisibility3 = false;
            }

        }
        public void MyCommandTestReceipt(object parm)
        {
            try
            {

                if ((string)parm == "1")
                {
                    UnitOfWork myunit = new UnitOfWork(ctx);
                    if (myunit.MyReceiptsRep.find(r => r.ReceiptNumber == MaterialReceipt.ReceiptNumber).Count() > 1)
                    {
                        ReceiptMessageQueue.Enqueue("شماره فاکتور وارد شده تکراری می باشد.");
                        ReceiptSnackIsActive = true;
                    }
                    else
                    {
                        myunit.MyReceiptsRep.Add(MaterialReceipt);
                        myunit.complete();
                        ctx.Entry(MaterialReceipt).State = System.Data.Entity.EntityState.Detached;
                        MaterialReceipt.CostValue = ""; MaterialReceipt.DateofIssue = "";
                        MaterialReceipt.IsPayed = 0; MaterialReceipt.Issuer = "";
                        MaterialReceipt.ReceiptNumber = ""; MaterialReceipt.TheProviderCompanyid = -1;
                        (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                        NamesofMaterialsob = getNamesofMaterials(null);
                        ReceiptMessageQueue.Enqueue("اطلاعات با موفقیت ثبت شد");
                        ReceiptSnackIsActive = true;
                    }


                }
                else
                {
                    DialogHostVisibility2 = false;
                }
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public void executeCancelbutton()
        {
            DialogHostVisibility2 = false;
        }
        public void executeCancelbuttonpersonel()
        {
            DialogHostVisibility3 = false;
        }
        public bool CanExecuteMyCommandTestReceipt(object parm)
        {
            if (propermaterialviewmode &&
                MaterialReceipt.ProperReceipt2
                && MaterialReceipt.ProperReceipt3 && MaterialReceipt.ProperReceipt4
                && (MaterialCompany!=null && MaterialCompany.NameofCompany!=null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
