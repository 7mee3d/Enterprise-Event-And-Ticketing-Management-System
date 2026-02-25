
using EETMS_BusinessLayer.EETMS_Constants;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Settings
{
    public sealed class clsEETMS_SettingPresentation
    {

        public static async Task _AnimationLables(double ResultNumber, Label LableToBeAni, int NumberHowToBeDelay = 5, bool IsTheLableMoney = false)
        {

            int Steps = 100;
            double StepValue = ResultNumber / Steps;
            double CurrentValue = clsEETMS_Constants.kZERO;


            for (int counter = clsEETMS_Constants.kZERO; counter <= Steps; counter += clsEETMS_Constants.kONE)
            {

                if (IsTheLableMoney)
                    LableToBeAni.Text = "$" + CurrentValue.ToString("N0");
                else LableToBeAni.Text = ((int)CurrentValue).ToString("");

                CurrentValue += StepValue;

                await Task.Delay(NumberHowToBeDelay);
            }



            if (IsTheLableMoney)
                LableToBeAni.Text = "$" + (ResultNumber).ToString("N0");
            else
                LableToBeAni.Text = ((int)ResultNumber).ToString("");
        }




    }
}
