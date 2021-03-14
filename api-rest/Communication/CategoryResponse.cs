using System;
using System.Collections.Generic;
using api_rest.Domains.Models;

namespace api_rest.Communication
{
    public class CategoryResponse : BaseResponse
    {

        public Category Category {get;private set;}

        //vai passar os parâmetros de sucesso e mensagem para a classe
        //base, e também define a propriedade Category;
        private CategoryResponse(bool success,string message,Category category):base(success,message){
            Category = category;
        }

        //criará uma resposta bem-sucedida, chamando o construtor privado para definir as
        //respectivas propriedades;
        public CategoryResponse(Category category): this(true,string.Empty,category){}
        
       //será usado para criar uma resposta de falha. 
        public CategoryResponse(string message) : this(false,message,null){}

    }
}