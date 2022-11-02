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

    AddArticle(article : Article)
    {
        console.log("oui 2")
        return this.http.get<any>(`${this.baseUri}/add`);
    }
}