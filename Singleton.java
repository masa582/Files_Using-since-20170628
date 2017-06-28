package com.util.csv;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

import org.apache.commons.io.output.FileWriterWithEncoding;

import com.opencsv.CSVWriter;

public class Singleton {
    private static Singleton inst= new Singleton();

    private Singleton() {
        super();
    }

    public static Singleton getInstance() {
    	if (inst == null)
    	{
    		inst = new Singleton();
    	}
    	return inst;
    }
    
    public synchronized void writeToFile(String csvOutputFile, List<String[]> rows, String encoding) {
		// save data in csv file
		CSVWriter csvWriter = null;
		try 
		{
			csvWriter = new CSVWriter(new FileWriterWithEncoding(csvOutputFile, encoding, true), ';');
		}
		catch (IOException e)
		{
			System.out.println(e.getMessage());
		}
		csvWriter.writeAll(rows);
		try {
			// closing the writer
			csvWriter.close();
		} catch (Exception ee) {
			ee.printStackTrace();
		}
    }

}