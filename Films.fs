module Practical3.Films

type IPrintable =
    abstract Print: string with get

type FeatureFilm =
    {
        m_title: string
        m_producer: string
    }

    //override this.ToString() =
    //    "Title: " + this.m_title + ", producer: " + this.m_producer + "\n"

    //interface IPrintable with
    //    override this.Print = "Title: " + this.m_title + ", producer: " + this.m_producer + "\n"

type CartoonType =
    | Drawn
    | Dollish
    | Plasticine

type CartoonFilm =
    {
        m_title: string
        m_type: CartoonType
    }

    //override this.ToString() =
    //    "Title: " + this.m_title + ", producer: " + this.m_type.ToString() + "\n"

    //interface IPrintable with
    //    override this.Print = "Title: " + this.m_title + ", producer: " + this.m_type.ToString() + "\n"

type HorrorFilm =
    {
        m_title: string
        m_producer: string
    }

type Film =
    | Feature of FeatureFilm
    | Cartoon of CartoonFilm
    | Horror of HorrorFilm
    | Incorrect
