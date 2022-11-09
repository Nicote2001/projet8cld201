import { Component, OnInit } from '@angular/core';
import { Article } from '../object/article';
import { ArticlesService } from '../services/articles.service';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'app-update-blog',
  templateUrl: './update-blog.component.html',
  styleUrls: ['./update-blog.component.css']
})
export class UpdateBlogComponent implements OnInit {
  
  article : Article;
  name:string = " ";
  text:string = " ";
  autor:string = " ";

  constructor(private service :ArticlesService, private route:ActivatedRoute) { }

  ngOnInit(): void {   
    this.route.params.subscribe(val => {
      this.service.getArticle(new Article(1,this.route.snapshot.params['name'],"","")).subscribe(data => {
        this.article = data;
        this.name = this.article.name;
        this.text = this.article.text;
        this.autor = this.article.autor;
      });
    });
  }

  save()
  {
    var item  = new Article(1,this.name,this.text,this.autor);
    this.service.Update(item).subscribe(data => {
      if(data == true){
        alert("marche");
      }
    });
  }

}
