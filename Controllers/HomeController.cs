using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carvajar_2._1.Models.Data;
using Carvajar_2._1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net.Mime;
using NuGet.Protocol.Plugins;
using System.Net;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net.Http;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Carvajar_2._1.Controllers
{
    
    public class HomeController : Controller
    {
        public REQUERIMIENTOSContext _context;
        private readonly IWebHostEnvironment _enviroment;

        private readonly string CadenaSQL;

        //private readonly IWebHostEnvironment _enviroment;


        public HomeController(IConfiguration config, REQUERIMIENTOSContext context, IWebHostEnvironment env)
        {
            _enviroment= env;
       
            _context = context;
            CadenaSQL = config.GetConnectionString("CadenaSql");
           
        }




        public IActionResult UserIndex()
        {
            return View();
        }



        public IActionResult Login()
        {
            return View();

        }






        [HttpPost]
        public async Task <IActionResult> Login(string correo, string contraseña)
        {

            var usuario = _context.Ingenieros.Where(user => user.Correo == correo && user.Contraseña == contraseña).FirstOrDefault();
            if (usuario !=null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, usuario.Nombre!),
                    new Claim("corre", usuario.Correo!),
					new Claim(ClaimTypes.Role, usuario.Rol!)
				};

                int id = usuario.IdIngeniero;
                string? rol = usuario.Rol;
				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                TempData["id"] = id;
                TempData["rol"] = rol;

                return RedirectToAction("Index", "Solicitudes", rol);
            }
            else
            {
                ViewData["Mensage"] = "Usuario no encontrado  ";
                return View();
            }


        }

        
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserIndex([Bind("IdSolicitante,Nombre,Identificacion,Correo,Telefono,Empresa, Cargo")] Solicitante cliente)
        {
            var usuario = _context.Solicitantes.Where(user => user.Identificacion == cliente.Identificacion).FirstOrDefault();
            if (usuario == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("CreateSolicitud", "Home", cliente);

                }
                return View(cliente);

            }
            else
            {
                return RedirectToAction("CreateSolicitud", "Home", cliente);
            }

           

        }

        
        public IActionResult CreateSolicitud(Solicitante cliente)
        {
            ViewBag.Solicitante = cliente.Nombre;
            ViewBag.Cliente = cliente.Empresa;
            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "Descripcion");
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "Descripcion");
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripcion");
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "IdIngeniero");
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Descripcion");
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "Descripcion");
            return View();
        }
       
        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSolicitud([Bind("Solicitante,Telefono,Correo,Cliente,IdTipo,Producto,IdCaracteristica,IdEstado,IdComplejidad,Descripcion,Estado,IdPeriodicidad,Email,AsuntoEmail,DominioCorpEmail,CuerpoEmail,NombrePdf,EncriptadoEmail,ClaveEmail,CertificadoEmail,DominioEmail,Sms,Mensaje,Fisico,Color,AislamientoFisico,TamanoFisico,TipoPapelFisico,TipoFisico,Microperforado,Pdf,TipoEntrega,Publicacion,ContenidoPublicacion,FechaSolicitud,FechaInicio,FechaPruebas,FechaAprobacion,FechaFinal,ReqFunc,ReqNoFunc,ReqAmbiente,IdIngeniero, Identificacion,ReqFuncFile,ReqNoFuncFile,ReqAmbienteFile")]Solicitud solicitude,string Correo, string Cliente, bool Email, IFormFile ReqFuncFile,  IFormFile ReqNoFuncFile, IFormFile ReqAmbienteFile)
        {
            try
            {
                if(ReqFuncFile != null) { 
                    if (ReqFuncFile.Length > 0)
                    {
                   

                        DateTime fecha = System.DateTime.Today;
                        //var hora = DateTime.Now.ToLongTimeString();
                        solicitude.ReqFuncFile = ReqFuncFile.FileName + fecha;
                        var path = Path.Combine(_enviroment.ContentRootPath, "Archivos");
                        string fullPath = Path.Combine(path, ReqFuncFile.FileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            ReqFuncFile.CopyTo(stream);
                        }

                    }
				}
                if (ReqNoFuncFile != null) {
				    if (ReqNoFuncFile.Length > 0)
                    {

                        DateTime fecha = System.DateTime.Today;
                        //var hora = DateTime.Now.ToLongTimeString();
                        solicitude.ReqNoFuncFile = ReqNoFuncFile.FileName + fecha;
                        var path = Path.Combine(_enviroment.ContentRootPath, "Archivos");
                        string fullPath2 = Path.Combine(path, ReqNoFuncFile.FileName);
                        using (var stream = new FileStream(fullPath2, FileMode.Create))
                        {
                            ReqNoFuncFile.CopyTo(stream);
                        }

                    }
				}
                if (ReqFuncFile != null)
                {
                    if (ReqAmbienteFile.Length > 0)
                    {


                        DateTime fecha = System.DateTime.Today;
                        //var hora = DateTime.Now.ToLongTimeString();
                        solicitude.ReqAmbienteFile = ReqAmbienteFile.FileName + fecha;
                        var path = Path.Combine(_enviroment.ContentRootPath, "Archivos");
                        string fullPath3 = Path.Combine(path, ReqAmbienteFile.FileName);
                        using (var stream = new FileStream(fullPath3, FileMode.Create))
                        {
                            ReqAmbienteFile.CopyTo(stream);
                        }

                    }
                }



               
                
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
            
           
            if (ModelState.IsValid)
            {
                solicitude.Email= Email;
                
                _context.Add(solicitude);
                await _context.SaveChangesAsync();

                ////ENVIO DE CORREOS
                var senderEmail = new MailAddress("makerwolf3d@gmail.com", "Carvajal Solicitudes");
                var receiverEmail = new MailAddress(Correo, "Receiver");
                var password = "vxzpksbkrrrqipbr";
                var sub = "Solicitud de empresa " + Cliente;
                var body = "El codigo de su solicitud es " + solicitude.IdSolicitud;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };

                var mailMessage = new MailMessage
                {
                    From = senderEmail,
                    Subject = sub,
                    Body = body,

                };

                mailMessage.To.Add(addresses: Correo);
                mailMessage.To.Add("makerwolf3d@gmail.com");

                {
                    smtp.Send(mailMessage);
                }

                return RedirectToAction(nameof(UserIndex));
            }




            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "IdCaracteristica", solicitude.IdCaracteristica);
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "IdComplejidad", solicitude.IdComplejidad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", solicitude.IdEstado);
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "IdIngeniero", solicitude.IdIngeniero);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "IdPeriodicidad", solicitude.IdPeriodicidad);
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "IdTipo", solicitude.IdTipo);
            return View(solicitude);
        }



        public async Task <IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserIndex", "Home");
        }




    }
        
    }
