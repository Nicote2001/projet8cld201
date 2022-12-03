import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Article } from '../object/article';
import { ArticlesService } from '../services/articles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  articles : Article[];

  constructor(private articleServices : ArticlesService,private router: Router)
  {
    this.getarticles();
  }

  ngOnInit(): void {
  }

  async getarticles()
  {
    await this.getarticlesCall();
  }

  async GoToUpdate(name : string)
  {
    this.router.navigateByUrl(`modifier/${name}`)
  }

 delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}

  async Delete(name : string)
  {
    await this.deleteCall(name);
    await this.delay(1000);
    this.getarticles();
  }

  async deleteCall(name : string){
    this.articleServices.Delete(new Article(1,name,"","")).subscribe(data => {
      if(data == true){
        alert("L'article \"" + name + "\" a été supprimé avec succès!");
      }else
      {
        alert("Une erreur est survenu lors de la suppression!");
      }
    });
  }


  async getarticlesCall()
  {
    this.articleServices.getAll().subscribe(data => {
      this.articles = data;
    });
  }
}
