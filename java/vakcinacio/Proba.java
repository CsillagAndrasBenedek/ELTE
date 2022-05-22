public class Proba{
    public static void main(String... args){
        Patient p = new Patient("Vakci Agi", 1966, "123456789", true);
        Patient q = new Patient("Vakci Agi", 1966, "123456789", true);
        System.out.println(q.equals(p.getName(), p.getYear(), p.getMobile(), p.getPaying()));
    }
}