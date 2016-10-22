package UML;

import java.text.NumberFormat;
import java.util.Locale;

import javax.swing.text.NumberFormatter;

public abstract class Employee {
	protected int ms;
	protected String name;
	protected  double luongcoban;
	public void setLuongcoban(double luongcoban) {
		this.luongcoban = luongcoban;
	}
	public abstract double getMonthSalary();
	public int getMs() {
		return ms;
	}
	public void setMs(int ms) {
		this.ms = ms;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public double getLuongcoban() {
		return luongcoban;
	}
	
	public Employee(int ms, String name, double luongcoban) {
		super();
		this.luongcoban=luongcoban;
		this.ms = ms;
		this.name = name;
	}
	@Override
	public String toString() {
		Locale local=new Locale("vi", "VN");
		NumberFormat a=NumberFormat.getCurrencyInstance(local);
		return  String.format("  ms:%d name:%s luongcanban: %s\n",ms,name,a.format(luongcoban)); 
	}
	
	
}
