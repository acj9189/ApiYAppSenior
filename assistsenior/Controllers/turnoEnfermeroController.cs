using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Persistencia.Modelos;
using AssistSenior.Models;

namespace AssistSenior.Controllers
{
	public class turnoEnfermeroController : ApiController
	{
	   
		assistseniorEntities BD = new assistseniorEntities();
		DateTime fechaactual = System.DateTime.Today;
	   [HttpGet]
		public IEnumerable<turnoEnfermero> Get()
		{
			var turnosEnfermeros = BD.turno_enfermero.Where(enferm => enferm.fecha>System.DateTime.Today)
				.Where(enferm=>enferm.estado=="Disponible").Select
				(e => new turnoEnfermero() { idTurno = e.idTurno, fecha = e.fecha,horaInicial=e.horaInicial,horaFinal=e.horaFinal,cedEnfermero=e.ced_enfermero,estado=e.estado})
				.ToList();  
				   
			return turnosEnfermeros;


		}

        [HttpPut]
        public void Put() {

        }
	}
}
  