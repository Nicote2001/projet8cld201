import { Component } from '@angular/core';
import { Article } from './object/article';
import { ArticlesService } from './services/articles.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  articles : Article[];

  constructor(private articleServices : ArticlesService)
  {
    this.getarticles();
  }

  async getarticles()
  {
    await this.getarticlesCall();
    console.log("oui", this.articles);
  }


  async getarticlesCall()
  {
    this.articleServices.getAll().subscribe(data => {
      console.log(data);
      this.articles = data;
    });
  }
}

