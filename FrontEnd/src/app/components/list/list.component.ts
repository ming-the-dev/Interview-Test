import { Component, OnInit } from '@angular/core';
import { IHero, IStat } from 'src/app/models/hero.interface';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes:IHero[] = [];
  stats:IStat[] = [];
  updatedHero:IHero = null;
  randomClass = [];
  class = ['color1', 'color2', 'color3', 'color4'];
  constructor(private apiService:ApiService) { }

  ngOnInit() {
    this.apiService.getHeroes().subscribe(res=>{
      this.heroes = <IHero[]>res;
      console.log('heroes: ', this.heroes)
      this.randomClass = [];
      for (let i=0; i<this.heroes.length; i++) {
        this.randomClass.push(this.class[Math.floor(Math.random() * this.class.length)]);
      }
    })
  }

  evolve(hero: IHero) {
    this.apiService.evolve(hero).subscribe(res=>{
      let heroResponse = <IHero>res;
      this.updatedHero = heroResponse;
      // this.updateHeroes(hero, heroResponse);
    })
  }

  updateHeroes(hero: IHero, newHero: IHero) {
    let index = this.heroes.indexOf(hero);
    this.heroes[index] = newHero;
  }

}
