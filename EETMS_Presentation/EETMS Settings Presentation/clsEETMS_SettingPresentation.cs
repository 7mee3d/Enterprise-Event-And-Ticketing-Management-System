
using EETMS_BusinessLayer.EETMS_Constants;
using Guna.UI2.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Settings
{
    public sealed class clsEETMS_SettingPresentation
    {

        public static async Task _AnimationLables(
            double ResultNumber,
            Label LableToBeAni,
            int NumberHowToBeDelay = 5,
            bool IsTheLableMoney = false)
        {

            int Steps = 100;
            double StepValue = ResultNumber / (float)Steps;
            double CurrentValue = clsEETMS_Constants.kZERO;


            for (int counter = clsEETMS_Constants.kZERO; counter <= Steps; counter += clsEETMS_Constants.kONE)
            {

                if (IsTheLableMoney)
                    LableToBeAni.Text = "$" + CurrentValue.ToString("0.00");
                else LableToBeAni.Text = ((int)CurrentValue).ToString("");

                CurrentValue += StepValue;

                await Task.Delay(NumberHowToBeDelay);
            }



            if (IsTheLableMoney)
                LableToBeAni.Text = "$" + (ResultNumber).ToString("0.00");
            else
                LableToBeAni.Text = ((int)ResultNumber).ToString("");
        }


        public static bool ShowTheMessageBoxUseTheMessageDialog(Guna2MessageDialog G2MD, string Text, string Caption, MessageDialogButtons messageDialogButtons, MessageDialogIcon messageDialogIcon)
        {
            G2MD = new Guna2MessageDialog();


            G2MD.Text = Text;
            G2MD.Caption = Caption;
            G2MD.Buttons = messageDialogButtons;
            G2MD.Icon = messageDialogIcon;

            DialogResult dialogResult = G2MD.Show();

            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
                return true;
            else return false;


        }


    }
}
