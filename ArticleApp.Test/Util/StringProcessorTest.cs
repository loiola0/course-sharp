using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArticleApp.API.Util;

namespace ArticleApp.Test.Util
{
    public class StringProcessorTest
    {

        [TestMethod]
        public void StringProcessorTesting(){
            string sentence = "Programando seu primeiro teste unitário";

            string d = StringProcessor.ToUpperCase(sentence);
            
                foreach (char c in d)
                {
                    if(c != ' '){
                        Assert.IsTrue(char.IsUpper(c));
                    }
                        
                }

        }
        
    }
}