package QLCD;

public class ListCD {
	CD [] list;
	int count;
	double sum=0;
	public ListCD() {
		list =new CD[100];
		count=0;
	}
	public ListCD(int n) {
		if(n>0)
			list =new CD[n];
		else 
			list=new CD[10];
		count=0;
	}
	public String themCD(int maCD,String tuaCD,double giathanh)
	{
		if(count>list.length)
			return "mang day khong them duoc nua\n";
		CD cd=new CD(maCD,tuaCD,giathanh);
		if(cd.getTrangthai().length()!=0)
			return cd.getTrangthai()+"thuoc tinh CD moi co du lieu mac nhien";
		list[count]=cd;
		count++;
		return "them thanh cong";
	}
	public int getSoluongCD()
	{
		return count;
	}
	//tim CD theo maCD
	public CD timCD1(int maCD)
	{
		for(int i=0;i<count;i++)
		{
			if(list[i].getMaCD()==maCD)
				return list[i];
		}
		return null;
	}
	public CD timCD2(String tuaCD)
	{
		for(int i=0;i<count;i++)
		{
			if(list[i].getTuaCD()==tuaCD)
				return list[i];
		}
		return null;
	}
	//in thong tin cd
	public String ttcd()
	{
		String ttcd="";
		for(int i=0;i<count;i++)
			ttcd+=list[i].toString();
		return ttcd;
	}
	public void sort1()
	{
		for(int i=0;i<count;i++)
			for(int j=i+1;j<count;j++)
				if(list[i].getGiathanh()<list[j].getGiathanh())
				{
					CD temp=list[i];
					list[i]=list[j];
					list[j]=temp;
				}
	}
	public double TongTien()
	{
		for(int i=0;i<count;i++)
			sum+=list[i].getGiathanh();
		return sum;
	}
	public void xoaCD(int maCD)
	{
		for(int i=0;i<count;i++)
		{
			if(list[i].getMaCD()==maCD)
			{
				list[i]=list[i+1];
				count--;
			}
		}
	}
}
