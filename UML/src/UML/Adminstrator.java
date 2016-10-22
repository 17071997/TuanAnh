package UML;

import java.text.NumberFormat;
import java.util.Locale;

public class Adminstrator extends Employee {

	public Adminstrator(int ms, String name, double luongcoban,String department) {
		super(ms, name, luongcoban);
		this.department=department;
		// TODO Auto-generated constructor stub
	}

	private String department;
	
	public String getDepartment() {
		return department;
	}

	public void setDepartment(String department) {
		this.department = department;
	}

	@Override
	public double getMonthSalary() {
		// TODO Auto-generated method stub
		return luongcoban+luongcoban*0.4;
	}
	@Override
	public String toString() {
		Locale local=new Locale("vi", "VN");
		NumberFormat a=NumberFormat.getCurrencyInstance(local);
		return "Adminstrator"+super.toString()+"bo phan: "+department+ String.format("luong:%s",a.format(getMonthSalary()));
	}

}
