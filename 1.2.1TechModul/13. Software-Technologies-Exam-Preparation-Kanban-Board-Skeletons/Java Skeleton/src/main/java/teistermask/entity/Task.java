package teistermask.entity;

import javax.persistence.*;

@Entity
@Table(name = "tasks")
public class Task {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(nullable = false)
	private String title;

	@Column(nullable = false)
	private String status;

	public Task() {
	}

	public Task(String title, String status) {
		this.title = title;
		this.status = status;
	}

	public int getId() {
		return this.id;
	}

	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getStatus() {
		return this.status;
	}

	public void setStatus(String status) {
		if (status.equals("Open") || status.equals("In Progress") || status.equals("Finished")) {
			this.status = status;
		} else {
			throw new IllegalArgumentException("Invalid status: " + status);
		}
	}
}
