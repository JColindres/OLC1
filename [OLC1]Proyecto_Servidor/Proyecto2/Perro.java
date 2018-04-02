public class Perro{
    public String nombre;
    public String raza;
    public String edad;

    public String Mascota(String nombreAux,String razaAux,int edadAux){
        nombre=nombreAux;
        raza=razaAux;
        edad=edadAux;
    }

    public String getInformacion(){
        String info="nombre:";
        return info;
    }
}