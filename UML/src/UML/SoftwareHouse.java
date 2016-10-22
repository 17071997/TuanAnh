package UML;

import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Locale;

public class SoftwareHouse implements Comparator<Employee>{

	public static void main(String[] args) {
		ArrayList<Employee> ds=new ArrayList<>();
		Programmer a = new Programmer(113,"Nguyen van a",5000000.0,"java");
		Programmer b = new Programmer(114,"Nguyen van b",6000000.0,"java");
		Programmer c = new Programmer(115,"Nguyen van c",4000000.0,"C#");
		Adminstrator d=new Adminstrator(117, "Tran Truong", 9000000.0, "IT");
		ProjectLeader q=new ProjectLeader(111, "Nguyen Cho", 7000000.0, "Java");
		Programmer w = new Programmer(112,"Nguyen van chung",4200000.0,"C#");
		ds.add(a);
		ds.add(b);
		ds.add(c);
		ds.add(d);
		ds.add(q);
		ds.add(w);
		for(Employee x: ds)
		{
			System.out.println(x);
		}
		System.out.println("so luong nhan vien: "+ds.size());
		System.out.println("tong luong nhan vien: "+tong(ds));
		for(Employee x:ds)
		{
			if(x instanceof Programmer)
			{
				if(compareTo((Programmer) x)==true)
				{
					System.out.println(x.getMonthSalary());
				}
			}
		}
		
	}
	public static  String tong(ArrayList<Employee> ds)
	{
		double s=0;
		Locale local=new Locale("vi", "VN");
		NumberFormat a=NumberFormat.getCurrencyInstance(local);
		for(Employee x: ds)
		{
			 s+= x.getMonthSalary();
		}
		return String.format("luong:%s",a.format(s));
		
	}
	public static boolean compareTo(Programmer x)
	{
		return "java".compareTo(x.getLanguage())==0;
	}
	@Override
	public int compare(Employee o1, Employee o2) {
		// TODO Auto-generated method stub
		return 0;
	}


}
