using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Altın_Toplama_Oyunu
{

    abstract class Gamer
    {
        public int goldAmount { set; get; }
        public int targetedX { set; get; }
        public int targetedY { set; get; }
        public int currentX { set; get; }
        public int currentY { set; get; }
        public int voyageCost { set; get; }
        public int stepLimit { set; get; } // describes step amount for one time voyage 
        public int decisionCost { set; get; }
        private List<Kordinat> goldLocations;

        public Gamer(int goldAmount,int voyageCost,int stepLimit, int decisionCost, List<Kordinat> goldLocations)
        {
            this.goldAmount = goldAmount;
            this.voyageCost = voyageCost;
            this.stepLimit = stepLimit;
            this.decisionCost = decisionCost;
            this.goldLocations = goldLocations; 
        }

        public abstract Kordinat setTarget(); 
        
        public void proceedToTarget()
        {
            int tempStepLimit = stepLimit;
            int calculatedValue = Math.Abs(targetedX - currentX);
            int shiftingAmountForX = calculatedValue > tempStepLimit ? tempStepLimit : calculatedValue;
            
            tempStepLimit -= shiftingAmountForX;
            currentY += targetedY>currentY ? tempStepLimit : -tempStepLimit     ;
            currentX += targetedX > currentX ? shiftingAmountForX : - shiftingAmountForX;


        }
        
    }
}
