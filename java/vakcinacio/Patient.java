public class Patient{
    private String name;
    private int year;
    private String mobile;
    private boolean paying;

    public Patient(String name, int year, String mobile, boolean paying){
        
        this.name = name;
        this.year = year;
        this.mobile = mobile;
        this.paying = paying;
    }

    public String getName() {return this.name;}
    public int getYear() {return this.year;} 
    public String getMobile() {return this.mobile;} 
    public boolean getPaying() {return this.paying;}
    
    public void setName(String name) {this.name = name;}
    public void setYear(int year) {this.year = year;}
    public void setMobile(String mobile) {this.mobile = mobile;}
    public void setPaying(boolean paying) {this.paying = paying;}

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append(this.name).append(" ").append(this.year).append(" ").append(this.mobile).append(" ").append(this.paying);
        return sb.toString();
    }

    public boolean equals(String name, int year, String mobile, boolean paying){
        /*
        System.out.println((this.name).compareTo(name)==0);
        System.out.println(this.year == year);
        System.out.println((this.mobile).compareTo(mobile)==0);
        System.out.println(this.paying == paying);
*/
    
    return (this.name).compareTo(name)==0 && this.year == year && (this.mobile).compareTo(mobile)==0 && this.paying == paying; 
}

}