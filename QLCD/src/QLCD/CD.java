package QLCD;

import java.text.NumberFormat;
import java.util.Locale;

public class CD {
	private int maCD;
	private String tuaCD;
	private int sobaihat;
	private double giathanh;
	private String trangthai;
	public String getTrangthai() {
		return trangthai;
	}
	public void setTrangthai(String trangthai) {
		this.trangthai = trangthai;
	}
	public int getMaCD() {
		return maCD;
	}
	public String setMaCD(int maCD) {
		if(maCD<0||maCD==999999)
			this.maCD = 999999;
		else 
			this.maCD=maCD;
		return "";
	}
	public String getTuaCD() {
		return tuaCD;
	}
	public String setTuaCD(String tuaCD) {
		if(tuaCD=="")
			this.tuaCD = "chua xac dinh";
		else 
			this.tuaCD=tuaCD;
		return "";
	}
	public int getSobaihat() {
		return sobaihat;
	}
	public String setSobaihat(int sobaihat) {
		if(sobaihat<=0)
		{
			this.sobaihat = 0;
		}
		else 
			this.sobaihat=sobaihat;
		return "";
			
	}
	public double getGiathanh() {
		return giathanh;
	}
	public String setGiathanh(double giathanh) {
		if(giathanh<=0)
			this.giathanh = 0;
		else 
			this.giathanh=giathanh;
		return "";
	}
	public CD() {
		super();
		trangthai="";
		this.maCD=999999;
		this.tuaCD="chua xac dinh";
		this.giathanh=0;
		trangthai+="thuoc tinh CD chua gia tri mac nhien";
	}
	public CD(int maCD, String tuaCD, double giathanh) {
		super();
		trangthai="";
		trangthai+=setMaCD(maCD);
		trangthai+=setTuaCD(tuaCD);
		trangthai+=setGiathanh(giathanh);
	}
	@Override
	public String toString() {
		Locale 	local=new Locale("vi","vn");
		NumberFormat formater = NumberFormat.getCurrencyInstance(local);
		return String.format("%10d %15s    %15s  \n",maCD,tuaCD,formater.format(giathanh));
	}
	
}
