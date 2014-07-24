using System;
using System.IO;
using NIST.BiCCL;
using Antlr.Runtime;

namespace NIST.BiCCL
{
    public class BiCCLController
    {           
        BiCCLParser parser;
        BiCCLLexer lexer;
        ANTLRFileStream inputStream;
        
        //This is the main import method.  Takes a BiCCL file,
        //parses it, loads the resulting XML into memory for later use.
        public void importBiCCLFile(string inputFilename)
        {   
            inputStream = new ANTLRFileStream(inputFilename);
            lexer = new BiCCLLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            parser = new BiCCLParser(tokens);
            //Parse the BiCCL file.
            parser.prog();
        }
 
        //Write the converted XML to a file.
        public void writeToFile(string fname)
        {
            //Sanity check
            if (fname == "")
            {
                throw new FileNotFoundException("Attempting to write to an empty filename.  Ignoring request.");
            }
            //make sure we've loaded a BiCCL file into memory already.
            if (parser == null)
            {
                throw new NullReferenceException("Haven't loaded a BiCCL file into memory yet, but are attempting to call BiCCLController::writeToFile.");
            }

            FileStream tempOutput = null;
            try
            {
                Console.WriteLine("Attempting to write out to file " + fname);
                tempOutput = new FileStream(fname, FileMode.OpenOrCreate);
                parser.writeXMLToStream(tempOutput);
                Console.WriteLine("Successfully wrote parser output to file " + fname);
            }
            catch (Exception e)
            {
                //This is very likely a user error (malformed BiCCL file, etc.), so don't crash, just let them know.
                Console.WriteLine("ERROR: Couldn't serialize BiCCL file to XML, error was :" + e.Message);
            }
            finally
            {
                tempOutput.Close();
            }
        }

        //Write the converted XML to a pre-defined Stream.
        public void writeToStream(Stream s)
        {
            Console.WriteLine("Attempting to write out to existing MemoryStream.");
            parser.writeXMLToStream(s);
            //Set the stream position back to 0.
            s.Position = 0;
            Console.WriteLine("Successfully wrote parser output to stream.");
    
        }

        //Returns a new MemoryStream which contains the converted XML.
        public MemoryStream writeNewStream()
        {
            Console.WriteLine("Attempting to write out to new MemoryStream.");
            MemoryStream theStream = new MemoryStream();
            parser.writeXMLToStream(theStream);
            //FIXME: TEMPORARY ONLY!
            //theStream.Position = 0;
            //for (int i = 0; i < theStream.Length; i++)
            //{
            //    Console.Write((char)theStream.ReadByte());
            //}
            

            //set the stream position back to 0.
            theStream.Position = 0;
            Console.WriteLine("Successfully wrote parser output to stream.");

            return theStream;
        } 
        
        //This is the complete, round-trip method.
        //Takes a BiCCL file, returns a MemoryStream containing the converted XML
        public MemoryStream convertBiCCLToMemoryStream(string inputFilename)
        {
            importBiCCLFile(inputFilename);
            return writeNewStream();
        }
    }
}