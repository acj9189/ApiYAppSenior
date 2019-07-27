﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistSenior.Models
{
	public class turnoEnfermero
	{
		public int idTurno { get; set; }
		public System.DateTime fecha { get; set; }
		public System.TimeSpan horaInicial { get; set; }
		public System.TimeSpan horaFinal { get; set; }
		public string estado { get; set; }
		public string cedEnfermero { get; set; }

	}
}