using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class Agent
    {
        public Agent() {
            State = EntityState.Enabled;
            IsContributer = true;
            ContributionRatioType = RatioType.Solid;
            ContributionAmount = 10000;
            IsOnCommission = true;
            CommissionRatioType = RatioType.Relative;
            IsOnSalary = false;
            salaryRatioType = RatioType.Solid;
            AgentType = AgentType.Representative;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Contact ContactDetails { get; set; }

        public AgentType AgentType { get; set; }

        private bool isContributer;
        public bool IsContributer
        {
            get { return isContributer; }
            set { isContributer = value;

                if (isContributer==false)
                {
                    ContributionAmount = 0;
                    ContributionPercentage = 0;
                    ContributionRatioType = null;
                }
            }

        }


        public double ContributionAmount { get; set; }
        public decimal ContributionPercentage { get; set; }
        
        private Nullable<RatioType> contributionRatioType;
        public Nullable<RatioType> ContributionRatioType
        {
            get { return contributionRatioType; }
            set {
                contributionRatioType = value;

                if (contributionRatioType==RatioType.Solid)
                {
                    ContributionPercentage = 0;
                }
                else if (contributionRatioType == RatioType.Fixed)
                {
                    ContributionAmount = 0;
                }
                else if (contributionRatioType == RatioType.Relative)
                {
                    ContributionPercentage = 0;
                    ContributionAmount = 0;
                }
            }
        }


        private bool isOnCommission;

        public bool IsOnCommission
        {
            get { return isOnCommission; }
            set { isOnCommission = value;

                if (isOnCommission == false)
                {
                    CommissionAmount = 0;
                    CommissionPercentage = 0;
                    CommissionRatioType = null;
                }
            }
        }


        public double CommissionAmount { get; set; }
        public decimal CommissionPercentage { get; set; }

        private Nullable<RatioType> commissionRatioType;
        public Nullable<RatioType> CommissionRatioType
        {
            get { return commissionRatioType; }
            set {
                commissionRatioType = value;

                if (commissionRatioType == RatioType.Solid)
                {
                    CommissionPercentage = 0;
                }
                else if (commissionRatioType == RatioType.Fixed)
                {
                    CommissionAmount = 0;
                }
                else if (commissionRatioType == RatioType.Relative)
                {
                    CommissionPercentage = 0;
                    CommissionAmount = 0;
                }
            }
        }

        private bool isOnSalary;
        public bool IsOnSalary
        {
            get { return isOnSalary; }
            set { isOnSalary = value;

                if (isOnSalary == false)
                {
                    SalaryAmount = 0;
                    SalaryPercentage = 0;
                    SalaryRatioType = null;
                }

            }
        }

        public double SalaryAmount { get; set; }
        public decimal SalaryPercentage { get; set; }

        private Nullable<RatioType> salaryRatioType;

        public Nullable<RatioType> SalaryRatioType
        {
            get { return salaryRatioType; }
            set { salaryRatioType = value;

                if (salaryRatioType == RatioType.Solid)
                {
                    SalaryPercentage = 0;
                }
                else if (salaryRatioType == RatioType.Fixed)
                {
                    SalaryAmount = 0;
                }
                else if (salaryRatioType == RatioType.Relative)
                {
                    SalaryPercentage = 0;
                    SalaryAmount = 0;
                }

            }
        }


        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
