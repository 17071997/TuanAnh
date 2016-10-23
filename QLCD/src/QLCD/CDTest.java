package QLCD;

import java.util.Scanner;



public class CDTest {

	public static void main(String[] args) {
		ListCD list=new ListCD(20);
		int count=0;
		int chon=0;
		do
		{
			chon=menu();
			switch(chon)
			{
			case 1:
				themCD(list);
				break;
			case 2:
				System.out.println("so CD hien co la:"+list.getSoluongCD());
				break;
			case 3:
				inTTCD(list);
				break;
			case 4:
				list.sort1();
				break;
			case 5:
				System.out.println("tong tien la:"+list.TongTien());
				break;
			}
		}while(chon!=6);
	}
	public static int menu()
	{
		int chonCV ;
		Scanner sc=new Scanner(System.in);
		System.out.println("1. Them CD");
		System.out.println("2. So CD hien co");
		System.out.println("3. In thong tin tat ca CD");
		System.out.println("4. Tinh gia thanh tat ca CD");
		System.out.println("5. Sap xep CD tang theo gia thanh");
		chonCV=sc.nextInt();
		return chonCV;
	}
	public static void inTTCD(ListCD list)
	{
		System.out.println(list.ttcd());
	}
	public static void themCD(ListCD list)
	{
		Scanner sc=new Scanner(System.in);
		int maCD;
		String tuaCD;
		double giathanh;
		System.out.println("Nhap ma CD");
		maCD=sc.nextInt();
		System.out.println("Nhap tua CD");
		sc.nextLine();
		tuaCD=sc.nextLine();
		System.out.println("Nhap gia thanh");
		giathanh=sc.nextDouble();
		CD cd=list.timCD1(maCD);
		if(list==null)
			System.out.println(list.themCD(maCD, tuaCD, giathanh));
		else
		{
			if(cd==null)
				System.out.println(list.themCD(maCD, tuaCD, giathanh));
			else 
				System.out.println("trung ma CD ko the them");
		}
	}
	
}
