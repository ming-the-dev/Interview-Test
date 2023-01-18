export interface IHero {
    name: string;
    power: string;
    stats: IStat[];
}

export interface IStat {
    [key: string]: number;
}