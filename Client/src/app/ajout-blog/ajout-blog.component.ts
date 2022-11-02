import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { serialize } from 'v8';
import { Article } from '../object/article';
import { ArticlesService } from '../services/articles.service';

@Component({
  selector: 'app-ajout-blog',
  templateUrl: './ajout-blog.component.html',
  styleUrls: ['./ajout-blog.component.css']
})
export class AjoutBlogComponent implements OnInit {

  title:string = " ";
  text:string = " ";
  autor:string = " ";
  

  constructor(private service :ArticlesService) { }

  ngOnInit(): void {
  }

  save()
  {
    var item  = new Article(1,this.title,this.text,this.autor);
     console.log("je test");
    this.service.AddArticle(item);
  }

}
