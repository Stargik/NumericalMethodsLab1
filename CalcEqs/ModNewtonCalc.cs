using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcEqs
{
    internal class ModNewtonCalc : IEqsFunction
    {
        double a;
        double b;
        double eps;
        Ilogger logger;
        Func<double, double> derivativeFunc;

        public ModNewtonCalc(double a, double b, Func<double, double> derivativeFunc, double eps, Ilogger logger)
        {
            this.a = a;
            this.b = b;
            this.derivativeFunc = derivativeFunc;
            this.eps = eps;
            this.logger = logger;
        }

        public double Calc(Func<double, double> func, double x0)
        {
            int n = 0;
            double xNext, xPrev, xBuf, resX0;
            xPrev = x0;
            resX0 = derivativeFunc(x0);
            xNext = xPrev - (func(xPrev) / resX0);
            n++;
            logger.Log(xNext, Math.Abs(xNext - xPrev));
            while (Math.Abs(xNext - xPrev) > eps)
            {
                xBuf = xNext;
                xNext = xNext - func(xNext) / resX0;
                xPrev = xBuf;
                n++;
                logger.Log(xNext, Math.Abs(xNext - xPrev));
            }
            logger.NCountLog("Апостеріорна оцінка", n);
            return xNext;
        }
    }
}
