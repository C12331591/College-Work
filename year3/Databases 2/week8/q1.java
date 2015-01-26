import java.sql.*;
import java.io.*;
import oracle.jdbc.driver.*;

public class Kennel
{
	public static void main (String args [])
	throws SQLException, IOException
	{
		try
		{
		  Class.forName("oracle.jdbc.driver.OracleDriver");
		  System.out.println("driver loaded");
		}
		catch (ClassNotFoundException e)
		{
			System.out.println ("Could not load the driver");
		}
		
		String servername = "redwood.ict.ad.dit.ie";
		String portnumber = "1521";
		String servicename = "pdb12c.ict.ad.dit.ie";
		String url = "jdbc:oracle:thin:@//" + servername + ":" + portnumber + "/" + servicename;// sid;
		/*String user, pass;
		user = readEntry("userid  : ");
		pass = readEntry("password: ");*/
	//    System.out.println(url);
		String user = "bwillis", pass = "C12331591";
		DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());
		//System.out.println ("before connection");

		Connection conn = DriverManager.getConnection(url, user, pass);
		Statement stmt = conn.createStatement ();

		ResultSet rset = stmt.executeQuery("select dname, oaddr from bwillis.lt_dog join lt_owner using (ownerid) where dogid = ");
		
		while (rset.next())
		{
			System.out.println(rset.getString(1) + " " + rset.getString(2));
		}
		
		stmt.close();
		conn.close();
	}
	//readEntry function -- to read input string
	static String readEntry(String prompt)
	{
		try
		{
			StringBuffer buffer = new StringBuffer();
			System.out.print(prompt);
			System.out.flush();
			int c = System.in.read();
			while (c != '\n' && c != -1) {
				buffer.append((char)c);
				c = System.in.read();
			}
			return buffer.toString().trim();
		}
		catch (IOException e)
		{
			return "";
		}
	}

	//readNumber function -- to read input number
	static int readNumber(String prompt)
	throws IOException
	{
		String snum;
		int num = 0;
		boolean numok;
		do
		{
			snum = readEntry(prompt);
			
			try
			{
				num = Integer.parseInt(snum);
				numok = true;
			}
			catch (NumberFormatException e)
			{
				numok = false;
				System.out.println("Invalid number; enter again");
			}
		} while (!numok);
		
		return num;
	}
}