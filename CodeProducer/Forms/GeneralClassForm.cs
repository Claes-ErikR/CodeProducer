using System.Collections.Generic;
using System.Windows.Forms;

namespace Utte.Code
{

    /// <summary>
    /// Main form for creating code for a general class
    /// </summary>
    public partial class GeneralClassForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public GeneralClassForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces the general class
        /// </summary>
        public override void Produce()
        {
            if (cpClassProduce.Valid)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = _basefilepath;
                    sfd.FileName = cpClassProduce.ClassName;
                    sfd.DefaultExt = "txt";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        using (ClassProducer newclass = new ClassProducer(cpClassProduce.ClassName, cpClassProduce.ClassAttributes, cpClassProduce.Type, cpClassProduce.ClassFormComponent, cpClassProduce.ClassVisibility, cpClassProduce.ClassParentClass, cpClassProduce.ClassDescription, sfd.FileName))
                        {
                            List<Member> members = cpClassProduce.GetMembers();
                            foreach (Member member in members)
                                newclass.AddMember(member);
                            List<ClassProducer> classproducers = cpClassProduce.GetClasses();
                            foreach (ClassProducer classproducer in classproducers)
                                newclass.AddClass(classproducer);
                            newclass.AddInterfaces(cpClassProduce.GetInterfaces());
                            newclass.AddImplementedInterfaces(cpClassProduce.GetImplementedInterfaces());
                            if (cpClassProduce.ImplementEqualityComparison && !newclass.IsStatic)
                                newclass.ImplementEqualityComparison();
                            if (cpClassProduce.ImplementOperators)
                                newclass.AddOperatorClass(cpClassProduce.ClassName);
                            if (cpClassProduce.OperatorsVsDouble)
                                newclass.AddOperatorClass("double");
                            if (cpClassProduce.OperatorsVsInt)
                                newclass.AddOperatorClass("int");
                            if (cpClassProduce.ImplementSortComparison)
                                newclass.ImplementSortComparison();
                            if (cpClassProduce.ImplementListWrapper)
                                newclass.ImplementListWrapper(cpClassProduce.ListWrapperType);
                            if (cpClassProduce.ImplementXmlReadSave)
                                newclass.ImplementXmlReadSave();
                            if (cpClassProduce.ImplementDeconstruct)
                                newclass.ImplementDeconstruct();
                            if (cpClassProduce.EnsureToStringOverridden)
                                newclass.EnsureToStringImplemented();

                            newclass.Produce();
                            ShowTextFile(sfd.FileName);
                        }
                    }
                }
            }
        }

        #endregion

    }
}