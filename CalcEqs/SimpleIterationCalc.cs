using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcEqs
{
    internal class SimpleIterationCalc : IEqsFunction
    {
        double a;
        double b;
        double q;
        double s;
        double eps;
        Ilogger logger;

        public SimpleIterationCalc(double a, double b, double q, double eps, Ilogger logger)
        {
            this.a = a;
            this.b = b;
            this.q = q;
            this.eps = eps;
            this.logger = logger;
        }

        public double Calc(Func<double, double> func, double x0)
        {
            double z = Math.Abs(func(x0) - x0);
            Console.WriteLine(z);
            int prevN = (int)Math.Truncate(Math.Log(z / ((1 - q) * eps)) / Math.Log(1 / q)) + 1;
            double res;
            int n = 0;
            double epsRes = eps;
            if (q < 0.5)
            {
                epsRes = (1 - q) * eps / q;
            }
            double xNext, xPrev, xBuf;
            xPrev = x0;
            xNext = func(x0);
            logger.Log(xNext, Math.Abs(xNext - xPrev));
            n++;
            while (Math.Abs(xNext - xPrev) > epsRes)
            {
                xBuf = xNext;
                xNext = func(xNext);
                xPrev = xBuf;
                n++;
                logger.Log(xNext, Math.Abs(xNext - xPrev));
            }
            logger.NCountLog("Апостеріорна оцінка", n);
            logger.NCountLog("Апріорна оцінка", prevN);
            return xNext;
        }
    }
}
