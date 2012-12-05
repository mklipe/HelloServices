//
// PetService.cs
//
// Author:
//       Tony Alexander Hild <tony_hild@yahoo.com>
//       Mauricio Klipe <mklipe@yahoo.com.br>
//
// Copyright (c) 2012 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;

namespace HelloServices
{

    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class PetService : RestServiceBase<Pet>
    {
        public override object OnGet (Pet pet)
        {
            var total = PetDatabase.Instance.Pets.Count();
            var page = int.Parse(Request.QueryString["page"]);
            var perPage = int.Parse(Request.QueryString["perpage"]);
            //var totalOfPages = (int)(total/perPage);
        
            if (pet.Id == Guid.Empty) {
                return from n in PetDatabase.Instance.Pets.
                    Skip((page - 1) * perPage).
                    Take(perPage) 
                    select n;
            }
            
            
            return (from n in PetDatabase.Instance.Pets 
                   where n.Id == pet.Id
                   select n).SingleOrDefault();
        }
    }
    
    [Route("/dogs")]
    [Route("/dogs/{Id}")]
    public class Dog : Pet
    {
    }

    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class DogService : RestServiceBase<Dog>
    {
        public override object OnGet (Dog dog)
        {
         if (dog.Id == Guid.Empty) {
                return from n in PetDatabase.Instance.Pets 
                    where n.GetType () == typeof(Dog)
                    select n;
            }
            return (from n in PetDatabase.Instance.Pets 
                where n.Id == dog.Id
                select  n).SingleOrDefault ();
        }

        public override object OnPost (Dog request)
        {
            PetDatabase.Instance.Pets.Add(request);
            return request;
        }
        
        public override object OnPut (Dog request)
        {
            Dog dog = (from n in PetDatabase.Instance.Pets 
                        where request.Id == n.Id
                        select  n).SingleOrDefault() as Dog;
            dog.Name = request.Name;
            return dog;
        }
        
        public override object OnDelete (Dog request)
        {
            PetDatabase.Instance.Pets.Remove(request);
            return PetDatabase.Instance.Pets;
        }

    }

    [Route("/cats")]
    [Route("/cats/{Id}")]
    public class Cat : Pet
    {
    }

    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class CatService : RestServiceBase<Cat>
    {
        public override object OnGet (Cat cat)
        {
         if (cat.Id == Guid.Empty) {
                return from n in PetDatabase.Instance.Pets 
                    where n.GetType () == typeof(Cat)
                    select n;
            }
            return (from n in PetDatabase.Instance.Pets 
                where n.Id == cat.Id
                select  n).SingleOrDefault ();
        }
        
        public override object OnPost (Cat request)
        {
            PetDatabase.Instance.Pets.Add(request);
            return request;
        }
        
        public override object OnPut (Cat request)
        {
            Cat cat = (from n in PetDatabase.Instance.Pets 
                       where request.Id == n.Id
                       select  n).SingleOrDefault() as Cat;
            cat.Name = request.Name;
            return cat;
        }
        
        public override object OnDelete (Cat request)
        {
            PetDatabase.Instance.Pets.Remove(request);
            return PetDatabase.Instance.Pets;
        }
    }


    [Route("/old/cats")]
    [Route("/old/cats/{Id}")]
    public class OldCat : Cat
    {
        public int Age { get; set; }
        public String Owner { get; set; }
    }
        
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class OldCatService : RestServiceBase<OldCat>
    {
        public override object OnGet (OldCat cat)
        {
            if (cat.Id == Guid.Empty) {
                return from n in PetDatabase.Instance.Pets 
                    where n.GetType () == typeof(OldCat)
                        select n;
            }
            return (from n in PetDatabase.Instance.Pets 
                    where n.Id == cat.Id
                    select  n).SingleOrDefault ();
        }
        
        public override object OnPost (OldCat request)
        {
            PetDatabase.Instance.Pets.Add(request);
            return request;
        }
        
        public override object OnPut (OldCat request)
        {
            OldCat cat = (from n in PetDatabase.Instance.Pets 
                       where request.Id == n.Id
                       select  n).SingleOrDefault() as OldCat;
            cat.Name = request.Name;
            cat.Age = request.Age;
            cat.Owner = cat.Owner;
            return cat;
        }
        
        public override object OnDelete (OldCat request)
        {
            PetDatabase.Instance.Pets.Remove(request);
            return PetDatabase.Instance.Pets;
        }
    }

    [Route("/parrots")]
    [Route("/parrots/{Id}")]
    public class Parrot : Pet
    {
    }

    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class ParrotService : RestServiceBase<Parrot>
    {
        public override object OnGet (Parrot parrot)
        {
         if (parrot.Id == Guid.Empty) {
                return from n in PetDatabase.Instance.Pets 
                    where n.GetType () == typeof(Parrot)
                    select n;
            }
            return (from n in PetDatabase.Instance.Pets 
                where n.Id == parrot.Id
                select  n).SingleOrDefault ();
        }
        
        public override object OnPost (Parrot request)
        {
            PetDatabase.Instance.Pets.Add(request);
            return request;
        }
        
        public override object OnPut (Parrot request)
        {
            Parrot parrot = (from n in PetDatabase.Instance.Pets 
                          where request.Id == n.Id
                             select  n).SingleOrDefault() as Parrot;
            parrot.Name = request.Name;
            return parrot;
        }
        
        public override object OnDelete (Parrot request)
        {
            PetDatabase.Instance.Pets.Remove(request);
            return PetDatabase.Instance.Pets;
        }
        
    }
   

    /// <summary>
    /// Define your ServiceStack web service request (i.e. the Request DTO).
    /// </summary>
    [Route("/pets/type/{PetType}")]
    public class Pets
    {
        public string PetType { get; set; }
    }

    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class PetsService : RestServiceBase<Pets>
    {
        public override object OnGet (Pets pets)
        {
//            if (string.IsNullOrEmpty (pets.PetType)) {
//                return from n in PetDatabase.Instace.Pets 
//                    select n;
//            }
            return from n in PetDatabase.Instance.Pets 
                where n.GetType ().Name.ToLower() == pets.PetType.ToLower()
                select n;
        }
    }

    public class PetDatabase
    {

        static PetDatabase _instance;
        static object _lock = new object ();
        IList <Pet> _pets = new List<Pet> ();

        public Pet this [int index] {
            get{ return _pets [index];}
        }

        public IList<Pet> Pets {
            get { return _pets;}
        }

        public static PetDatabase Instance {
            get {
                if (_instance == null) {
                    lock (_lock) {
                        _instance = new PetDatabase ();
                        _instance._pets.Add (new Dog (){Name = "Spike", Id = Guid.NewGuid()});
                        _instance._pets.Add (new Dog (){Name = "Bo", Id = Guid.NewGuid()});
                        _instance._pets.Add (new Dog (){Name = "Mike", Id = Guid.NewGuid()});
                        _instance._pets.Add (new Cat (){Name = "Kitty", Id = Guid.NewGuid()});
                        _instance._pets.Add (new Cat (){Name = "Mimi", Id = Guid.NewGuid()});
                        _instance._pets.Add (new OldCat (){Name = "FurBall", Id = Guid.NewGuid() , Age = 10, Owner = "Mauricio"});
                        _instance._pets.Add (new OldCat (){Name = "Bisteca", Id = Guid.NewGuid() , Age = 3, Owner = "Joaquim"});
                        _instance._pets.Add (new Parrot (){Name = "Polly", Id = Guid.NewGuid()});
                        _instance._pets.Add (new Parrot (){Name = "Rico", Id = Guid.NewGuid()});
                    }
                }
                return _instance;
            }
        }

    }

}

