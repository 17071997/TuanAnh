package UML;

import java.text.NumberFormat;
import java.util.Locale;

public class Programmer extends Employee {

	private String language;
	
	@Override
	public double getMonthSalary() {
		return luongcoban+luongcoban*0.2;
	}
	public Programmer(int ms, String name, double luongcoban,String language) {
		super(ms, name, luongcoban);
		this.language=language;
	}
	@Override
	public String toString() {
		Locale local=new Locale("vi", "VN");
		NumberFormat a=NumberFormat.getCurrencyInstance(local);
		return "Programmer"+super.toString()+"language "+this.language+ String.format("luong:%s",a.format(getMonthSalary()));
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
}