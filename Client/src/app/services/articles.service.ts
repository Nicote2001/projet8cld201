import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";
import { Article } from "../object/article";

@Injectable({
    providedIn: 'root'
})
export class ArticlesService {
    constructor(private http: HttpClient) { }

    get baseUri() {
        return '/api';
    }

    getAll() {
        return this.http.get<any>(`${this.baseUri}/articles`);
    }

    getArticle(article : any) {
        return this.http.post<any>(`${this.baseUri}/articles/getarticle/`,article);
    }

    AddArticle(article : any)
    {
        return this.http.post<any>(`${this.baseUri}/articles/`,article);
    }

    Update(article : any)
    {
        return this.http.post<any>(`${this.baseUri}/articles/update`,article);
    }

    Delete(article : any)
    {
        return this.http.post<any>(`${this.baseUri}/articles/delete`,article);
    }
}