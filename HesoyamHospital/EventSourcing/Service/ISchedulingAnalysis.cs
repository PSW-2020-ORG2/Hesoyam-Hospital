using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Service
{
    public interface ISchedulingAnalysis
    {
        double GetPercentageOfSuccessfullyScheduledAppointments();
        public Dictionary<int, double> GetPercentageOfReturningBackByStep();
        public double GetMeanValueOfBackStepsPerScheduling();
        public double GetMeanValueOfStepsPerScheduling();
        public Dictionary<int, double> GetMeanValueOfTimeSpentByStep();
        public double GetAverageTimeForScheduling();
        public double GetAverageTimeForSuccessfulScheduling();
        public double GetAverageTimeForUnsuccessfulScheduling();
        public Dictionary<int, double> GetPercentageOfQuittingSchedulingByStep();
    }
}
