using System;

namespace EjerciciosEventosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIO 1: VENTAS ===");
            EjecutarEjercicio1();

            Console.WriteLine("\n=== EJERCICIO 2: INVERNADERO ===");
            EjecutarEjercicio2();

            Console.WriteLine("\n=== EJERCICIO 3: BACKUPS ===");
            EjecutarEjercicio3();

            Console.WriteLine("\n=== EJERCICIO 4: SENSORES DE SEGURIDAD ===");
            EjecutarEjercicio4();

            Console.WriteLine("\n=== EJERCICIO 5: CONSUMO DE ENERGÍA ===");
            EjecutarEjercicio5();
        }

        static void EjecutarEjercicio1()
        {
            var registroVentas = new Ejercicio1.RegistroVentas();
            var servicioRegistro = new Ejercicio1.ServicioRegistro();
            var servicioNotificacion = new Ejercicio1.ServicioNotificacion();

            registroVentas.VentaRealizada += servicioRegistro.RegistrarVenta;
            registroVentas.VentaRealizada += servicioNotificacion.EnviarNotificacionVenta;

            registroVentas.ProcesarVenta("Monitor 27 pulgadas", 249.99m);
        }

        static void EjecutarEjercicio2()
        {
            var controlTemp = new Ejercicio2.ControlTemperatura(umbral: 30.0);
            var servicioAlerta = new Ejercicio2.ServicioAlerta();
            var servicioRegistro = new Ejercicio2.ServicioRegistroTemperatura();

            controlTemp.TemperaturaAlta += servicioAlerta.EnviarAlerta;
            controlTemp.TemperaturaAlta += servicioRegistro.RegistrarTemperatura;

            controlTemp.VerificarTemperatura(26.5);
            controlTemp.VerificarTemperatura(33.2);
        }

        static void EjecutarEjercicio3()
        {
            var gestorBackups = new Ejercicio3.GestorBackups();
            var servicioNotificacion = new Ejercicio3.ServicioNotificacion();
            var servicioLog = new Ejercicio3.ServicioLog();

            gestorBackups.BackupCompletado += servicioNotificacion.NotificarBackup;
            gestorBackups.BackupCompletado += servicioLog.RegistrarBackup;

            gestorBackups.RealizarBackup("base_datos_clientes.sql");
        }

        static void EjecutarEjercicio4()
        {
            var sensor = new Ejercicio4.SensorMonitoreo(horaInicioPermitida: 8, horaFinPermitida: 20);
            var servicioAlarma = new Ejercicio4.ServicioAlarma();
            var servicioIncidencias = new Ejercicio4.ServicioRegistroIncidencias();

            sensor.AlertaIntruso += servicioAlarma.ActivarAlarma;
            sensor.AlertaIntruso += servicioIncidencias.GuardarIncidencia;

            sensor.DetectarApertura("Puerta Principal", new DateTime(2026, 11, 24, 14, 30, 0));
            sensor.DetectarApertura("Ventana Salón", new DateTime(2026, 11, 24, 23, 15, 0));
        }

        static void EjecutarEjercicio5()
        {
            var monitorEnergia = new Ejercicio5.MonitorEnergia(umbralConsumo: 3500.0);
            var servicioNotificacion = new Ejercicio5.ServicioNotificacion();
            var servicioAjuste = new Ejercicio5.ServicioAjusteAutomatizado();

            monitorEnergia.ConsumoExcesivoDetectado += servicioNotificacion.EnviarAdvertencia;
            monitorEnergia.ConsumoExcesivoDetectado += servicioAjuste.AjustarDispositivos;

            monitorEnergia.RegistrarConsumo(2100.0);
            monitorEnergia.RegistrarConsumo(4200.5);
        }
    }
}

// ============================================================================
// EJERCICIO 1: Sistema de Registro y Notificación de Ventas
// ============================================================================
namespace Ejercicio1
{
    public class VentaEventArgs : EventArgs
    {
        public string Producto { get; }
        public decimal Precio { get; }

        public VentaEventArgs(string producto, decimal precio)
        {
            Producto = producto;
            Precio = precio;
        }
    }

    public class RegistroVentas
    {
        public event EventHandler<VentaEventArgs>? VentaRealizada;

        public void ProcesarVenta(string producto, decimal precio)
        {
            Console.WriteLine($"Procesando venta: {producto} ({precio:C})...");
            OnVentaRealizada(new VentaEventArgs(producto, precio));
        }

        protected virtual void OnVentaRealizada(VentaEventArgs e)
        {
            VentaRealizada?.Invoke(this, e);
        }
    }

    public class ServicioRegistro
    {
        public void RegistrarVenta(object? sender, VentaEventArgs e)
        {
            Console.WriteLine($"[Registro] Venta guardada -> Producto: {e.Producto}, Precio: {e.Precio:C}");
        }
    }

    public class ServicioNotificacion
    {
        public void EnviarNotificacionVenta(object? sender, VentaEventArgs e)
        {
            Console.WriteLine($"[Notificación] ¡Gracias por su compra de '{e.Producto}' por {e.Precio:C}!");
        }
    }
}

// ============================================================================
// EJERCICIO 2: Sistema de Control de Temperatura en un Invernadero
// ============================================================================
namespace Ejercicio2
{
    public class TemperaturaEventArgs : EventArgs
    {
        public double TemperaturaActual { get; }
        public double Umbral { get; }

        public TemperaturaEventArgs(double temperaturaActual, double umbral)
        {
            TemperaturaActual = temperaturaActual;
            Umbral = umbral;
        }
    }

    public class ControlTemperatura
    {
        private readonly double _umbral;
        public event EventHandler<TemperaturaEventArgs>? TemperaturaAlta;

        public ControlTemperatura(double umbral)
        {
            _umbral = umbral;
        }

        public void VerificarTemperatura(double temperaturaActual)
        {
            Console.WriteLine($"Lectura actual del invernadero: {temperaturaActual} °C (Umbral: {_umbral} °C)");
            if (temperaturaActual > _umbral)
            {
                OnTemperaturaAlta(new TemperaturaEventArgs(temperaturaActual, _umbral));
            }
        }

        protected virtual void OnTemperaturaAlta(TemperaturaEventArgs e)
        {
            TemperaturaAlta?.Invoke(this, e);
        }
    }

    public class ServicioAlerta
    {
        public void EnviarAlerta(object? sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"[ALERTA] ¡Temperatura crítica! {e.TemperaturaActual} °C supera el umbral de {e.Umbral} °C.");
        }
    }

    public class ServicioRegistroTemperatura
    {
        public void RegistrarTemperatura(object? sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"[Log Temperatura] Registrado pico térmico: {e.TemperaturaActual} °C.");
        }
    }
}

// ============================================================================
// EJERCICIO 3: Sistema de Backup y Notificación de Archivos
// ============================================================================
namespace Ejercicio3
{
    public class BackupEventArgs : EventArgs
    {
        public string NombreArchivo { get; }
        public DateTime Fecha { get; }

        public BackupEventArgs(string nombreArchivo, DateTime fecha)
        {
            NombreArchivo = nombreArchivo;
            Fecha = fecha;
        }
    }

    public class GestorBackups
    {
        public event EventHandler<BackupEventArgs>? BackupCompletado;

        public void RealizarBackup(string nombreArchivo)
        {
            Console.WriteLine($"Creando copia de seguridad de '{nombreArchivo}'...");
            OnBackupCompletado(new BackupEventArgs(nombreArchivo, DateTime.Now));
        }

        protected virtual void OnBackupCompletado(BackupEventArgs e)
        {
            BackupCompletado?.Invoke(this, e);
        }
    }

    public class ServicioNotificacion
    {
        public void NotificarBackup(object? sender, BackupEventArgs e)
        {
            Console.WriteLine($"[Notificación] Copia de seguridad de '{e.NombreArchivo}' finalizada con éxito.");
        }
    }

    public class ServicioLog
    {
        public void RegistrarBackup(object? sender, BackupEventArgs e)
        {
            Console.WriteLine($"[Log Backup] Archivo: {e.NombreArchivo} | Fecha: {e.Fecha:dd/MM/yyyy HH:mm:ss}");
        }
    }
}

// ============================================================================
// EJERCICIO 4: Sistema de Monitoreo de Sensores de Puertas y Ventanas
// ============================================================================
namespace Ejercicio4
{
    public class IntrusoEventArgs : EventArgs
    {
        public string NombreSensor { get; }
        public DateTime HoraDeteccion { get; }

        public IntrusoEventArgs(string nombreSensor, DateTime horaDeteccion)
        {
            NombreSensor = nombreSensor;
            HoraDeteccion = horaDeteccion;
        }
    }

    public class SensorMonitoreo
    {
        private readonly int _horaInicioPermitida;
        private readonly int _horaFinPermitida;
        public event EventHandler<IntrusoEventArgs>? AlertaIntruso;

        public SensorMonitoreo(int horaInicioPermitida, int horaFinPermitida)
        {
            _horaInicioPermitida = horaInicioPermitida;
            _horaFinPermitida = horaFinPermitida;
        }

        public void DetectarApertura(string nombreSensor, DateTime horaDeteccion)
        {
            Console.WriteLine($"Sensor '{nombreSensor}' activado a las {horaDeteccion:HH:mm}.");
            if (horaDeteccion.Hour < _horaInicioPermitida || horaDeteccion.Hour >= _horaFinPermitida)
            {
                OnAlertaIntruso(new IntrusoEventArgs(nombreSensor, horaDeteccion));
            }
        }

        protected virtual void OnAlertaIntruso(IntrusoEventArgs e)
        {
            AlertaIntruso?.Invoke(this, e);
        }
    }

    public class ServicioAlarma
    {
        public void ActivarAlarma(object? sender, IntrusoEventArgs e)
        {
            Console.WriteLine($"[ALARMA ACTIVADA] ¡Intrusión detectada en {e.NombreSensor} a las {e.HoraDeteccion:HH:mm}!");
        }
    }

    public class ServicioRegistroIncidencias
    {
        public void GuardarIncidencia(object? sender, IntrusoEventArgs e)
        {
            Console.WriteLine($"[Base de Datos] Incidencia guardada -> Ubicación: {e.NombreSensor}, Hora: {e.HoraDeteccion}");
        }
    }
}

namespace Ejercicio5
{
    public class EnergiaEventArgs : EventArgs
    {
        public double ConsumoActual { get; }
        public double Umbral { get; }

        public EnergiaEventArgs(double consumoActual, double umbral)
        {
            ConsumoActual = consumoActual;
            Umbral = umbral;
        }
    }

    public class MonitorEnergia
    {
        private readonly double _umbralConsumo;
        public event EventHandler<EnergiaEventArgs>? ConsumoExcesivoDetectado;

        public MonitorEnergia(double umbralConsumo)
        {
            _umbralConsumo = umbralConsumo;
        }

        public void RegistrarConsumo(double consumoActual)
        {
            Console.WriteLine($"Consumo eléctrico registrado: {consumoActual} W (Umbral: {_umbralConsumo} W)");
            if (consumoActual > _umbralConsumo)
            {
                OnConsumoExcesivoDetectado(new EnergiaEventArgs(consumoActual, _umbralConsumo));
            }
        }

        protected virtual void OnConsumoExcesivoDetectado(EnergiaEventArgs e)
        {
            ConsumoExcesivoDetectado?.Invoke(this, e);
        }
    }

    public class ServicioNotificacion
    {
        public void EnviarAdvertencia(object? sender, EnergiaEventArgs e)
        {
            Console.WriteLine($"[Advertencia] Consumo excesivo ({e.ConsumoActual} W). Ha superado el límite de {e.Umbral} W.");
        }
    }

    public class ServicioAjusteAutomatizado
    {
        public void AjustarDispositivos(object? sender, EnergiaEventArgs e)
        {
            Console.WriteLine($"[Automatización] Reduciendo potencia de climatización y electrodomésticos no esenciales...");
        }
    }
}