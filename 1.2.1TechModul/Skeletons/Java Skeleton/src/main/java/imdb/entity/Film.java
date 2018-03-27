package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;

	@Column(nullable = false)
	private String name;

	@Column(nullable = false)
	private String genre;

	@Column(nullable = false)
	private String director;

	@Column(nullable = false)
	private Integer year;

	public Film() {
	}

	public Film(String name, String genre, String director, Integer year) {
		this.name = name;
		this.genre = genre;
		this.director = director;
		this.year = year;
	}

	public Integer getId() {
		return this.id;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getGenre() {
		return this.genre;
	}

	public void setGenre(String genre) {
		this.genre = genre;
	}

	public String getDirector() {
		return this.director;
	}

	public void setDirector(String director) {
		this.director = director;
	}

	public Integer getYear() {
		return this.year;
	}

	public void setYear(Integer year) {
		this.year = year;
	}
}