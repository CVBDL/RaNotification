﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RaNotification.Data;
using RaNotification.Data.Mail;
using RaNotification.Way.Mail;

namespace RaNotification.APIServer.Controllers
{
    public class MailNotificationController : ApiController
    {
        // POST: api/MailNotification
        public IHttpActionResult Post([FromBody]MailEntity entity)
        {
            try
            {
                var agent = new MailAgent(
                    new MailConfig
                    {
                        SmtpServer = "*.com",
                        Port = 25
                    });

                CoerceEntity(entity);

                if (!agent.Send(entity))
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private void CoerceEntity(MailEntity entity)
        {
            if (entity == null)
                return;

            if (string.IsNullOrWhiteSpace(entity.From))
                entity.From = "noreply-ranotification@ra.rockwell.com";
        }
    }
}
