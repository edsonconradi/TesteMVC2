using Infra.Data.Context;
using Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Infra.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private MvcContext db = new MvcContext();

        // GET api/Cliente
        public IQueryable<Cliente> GetClientes()
        {           
                
            var   teste =  db.Clientes;


            return teste;
        }

        // GET api/Cliente/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente Cliente = db.Clientes.Find(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            return Ok(Cliente);
        }

        // PUT api/Cliente/5
        public IHttpActionResult PutCliente(int id, Cliente Cliente)
        {

            if (id != Cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(Cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Cliente
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente Cliente)
        {

            db.Clientes.Add(Cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Cliente.Id }, Cliente);
        }

        // DELETE api/Cliente/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente Cliente = db.Clientes.Find(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(Cliente);
            db.SaveChanges();

            return Ok(Cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }

    }
}
