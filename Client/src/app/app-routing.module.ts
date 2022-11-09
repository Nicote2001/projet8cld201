import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AjoutBlogComponent } from './ajout-blog/ajout-blog.component';
import { HomeComponent } from './home/home.component';
import { UpdateBlogComponent } from './update-blog/update-blog.component';

const routes: Routes = 
[
    {path: '', component: HomeComponent},
    {path: 'ajouter', component: AjoutBlogComponent},
    {path: 'modifier/:name', component: UpdateBlogComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
    imports:
    [
        RouterModule.forRoot(routes)
    ],
    exports:
    [
        RouterModule
    ]
})
export class AppRoutingModule {}
