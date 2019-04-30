using AppCareClinicMed.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Data {
    public class SeedingService {

        private AppCareClinicMedContext _context;

        public SeedingService(AppCareClinicMedContext context) {
            _context = context;
        }

        public void Seed() {

            if(_context.ESPECIALIDADE.Any() || _context.CONVENIO.Any() || _context.ESTADOS.Any() || _context.PAIS.Any()) {
                return; // banco de dados já foi populado
            }

            #region Estados
            ESTADOS e1 = new ESTADOS("AC");
            ESTADOS e2 = new ESTADOS("AL");
            ESTADOS e3 = new ESTADOS("AP");
            ESTADOS e4 = new ESTADOS("AM");
            ESTADOS e5 = new ESTADOS("BA");
            ESTADOS e6 = new ESTADOS("CE");
            ESTADOS e7 = new ESTADOS("DF");
            ESTADOS e8 = new ESTADOS("ES");
            ESTADOS e9 = new ESTADOS("GO");
            ESTADOS e10 = new ESTADOS("MA");
            ESTADOS e11 = new ESTADOS("MT");
            ESTADOS e12 = new ESTADOS("MS");
            ESTADOS e13 = new ESTADOS("MG");
            ESTADOS e14 = new ESTADOS("PA");
            ESTADOS e15 = new ESTADOS("PB");
            ESTADOS e16 = new ESTADOS("PR");
            ESTADOS e17 = new ESTADOS("PE");
            ESTADOS e18 = new ESTADOS("PI");
            ESTADOS e19 = new ESTADOS("RJ");
            ESTADOS e20 = new ESTADOS("RN");
            ESTADOS e21 = new ESTADOS("RS");
            ESTADOS e22 = new ESTADOS("RO");
            ESTADOS e23 = new ESTADOS("RR");
            ESTADOS e24 = new ESTADOS("SC");
            ESTADOS e25 = new ESTADOS("SP");
            ESTADOS e26 = new ESTADOS("SE");
            ESTADOS e27 = new ESTADOS("TO");
            #endregion

            #region Convenios
            CONVENIO c1 = new CONVENIO("Unimed");
            CONVENIO c2 = new CONVENIO("Amil");
            CONVENIO c3 = new CONVENIO("Bradesco Saúde");
            CONVENIO c4 = new CONVENIO("SulAmerica Saúde");
            #endregion

            #region Especialidades
            ESPECIALIDADE es1 = new ESPECIALIDADE("Cardiologista");
            ESPECIALIDADE es2 = new ESPECIALIDADE("Dermatologista");
            ESPECIALIDADE es3 = new ESPECIALIDADE("Ginecologista");
            ESPECIALIDADE es4 = new ESPECIALIDADE("Infectologista");
            ESPECIALIDADE es5 = new ESPECIALIDADE("Neurologista");
            ESPECIALIDADE es6 = new ESPECIALIDADE("Ortopedista");
            ESPECIALIDADE es7 = new ESPECIALIDADE("Urologista");
            #endregion

            string json = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"/wwwroot/Json/paises.json");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PAIS>>(json);
            foreach (var item in result) {
                PAIS p = new PAIS(item.Pais);
                _context.AddRange(p);
            }

            _context.AddRange(c1, c2, c3, c4);
            _context.AddRange(es1, es2, es3, es4, es5, es6, es7);
            _context.AddRange(e1, e2, e3, e4, e5, e6, e7, e8, e9, 
                e10, e11, e12, e13, e14, e15, e16, e17, e18, e19, e20, e21, e22, e23, e24, e25, e26, e27);

            _context.SaveChanges();
        }


    }
}
