using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AssistSenior.Controllers;
using AssistSenior.Models;
using Persistencia.Modelos;

namespace Tests
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {
        }

         /***
         * Casos de Prueba para el metdo get de la Api...
         */ 

        [Test]
        public void cadoPruebaGetEnfermeroApiEqual()
        {
            EnfermeroController enfermeroController = new EnfermeroController();
            Assert.Equals(enfermeroController.Get(), consulta());
        }
            

        [Test]
        public void cadoPruebaGetEnfermeroApiEqualNull()
        {
            EnfermeroController enfermeroController = new EnfermeroController();
            Assert.AreNotEqual(enfermeroController.Get(), consulta());
        }

        [Test]
        public void cadoPruebaGetEnfermeroApiException()
        {
            EnfermeroController enfermeroController = new EnfermeroController();
            Assert.That(enfermeroController.Get(), Throws.ArgumentException.With.Property("Message"));

        }

        [Test]
        public void cadoPruebaGetEnfermeroApiDatoNOValido()
        {
            EnfermeroController enfermeroController = new EnfermeroController();
            Assert.Null(enfermeroController.Get());
        }

         /***
         * Casos de Prueba para el metdo put de la Api...
         */

        //[Test]
        //public void cadoPruebaPutEnfermeroApiEqual()
        //{
        //    Assert.Pass();
        //}
 
        //[Test]
        //public void cadoPruebaPutEnfermeroApiEqualNull()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void cadoPruebaPutEnfermeroApiException()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void cadoPruebaPutEnfermeroApiDatoNOValido()
        //{
        //    Assert.Pass();
        //}

        private List<turnoEnfermero> consulta() {
            assistseniorEntities BD = new assistseniorEntities();
            var turnosEnfermeros = BD.turno_enfermero.Where(enferm => enferm.fecha > DateTime.Today)
                .Where(enferm => enferm.estado == "Disponible").Select
                (e => new turnoEnfermero() { idTurno = e.idTurno, fecha = e.fecha, horaInicial = e.horaInicial, horaFinal = e.horaFinal, cedEnfermero = e.ced_enfermero, estado = e.estado })
                .ToList();
            return turnosEnfermeros;
        }
    }
}