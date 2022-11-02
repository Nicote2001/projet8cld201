import { Component, OnInit } from '@angular/core';
import { Article } from '../object/article';
import { ArticlesService } from '../services/articles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  articles : Article[];

  constructor(private articleServices : ArticlesService)
  {
    this.getarticles();
  }

  ngOnInit(): void {
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
