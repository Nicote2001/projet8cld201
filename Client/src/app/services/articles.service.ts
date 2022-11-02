import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";

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
}